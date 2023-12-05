using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Trolley.API.Dtos;
using Trolley.API.Entities;

namespace Trolley.API.Services
{
    public class TemporaryShoppingListService : BaseService
    {
        private readonly IMemoryCache _cache;
        public TemporaryShoppingListService(IServiceProvider serviceProvider, IMemoryCache cache) : base(serviceProvider)
        {
            _cache = cache;
        }

        public async Task<List<TempMarketCostDto>> AddProductAndCalculateCostsPerMarketAsync(TempProductToAddDto tempProductToAddDto, string uniqueToken)
        {
            var cacheKey = $"TempShoppingList_{uniqueToken}";

            if (!_cache.TryGetValue(cacheKey, out List<ProductShoppingList> tempList))
            {
                tempList = new List<ProductShoppingList>();
            }

            tempList.Add(new ProductShoppingList { ProductId = tempProductToAddDto.ProductId, Amount = tempProductToAddDto.Amount });
            _cache.Set(cacheKey, tempList);

            var marketCosts = await CalculateCostsPerMarketAsync(tempList);
            return marketCosts.Select(mc => new TempMarketCostDto { MarketName = mc.Key, TotalPrice = mc.Value }).ToList();
        }




        private async Task<Dictionary<string, double>> CalculateCostsPerMarketAsync(List<ProductShoppingList> tempList)
        {
            var result = new Dictionary<string, double>();

            foreach (var tempItem in tempList)
            {
                // Überspringe, wenn ProductId null ist
                if (!tempItem.ProductId.HasValue)
                {
                    continue;
                }

                var product = await _context.Products
                    .Include(p => p.MarketProducts)
                    .ThenInclude(mp => mp.Market)
                    .FirstOrDefaultAsync(p => p.Id == tempItem.ProductId.Value);

                if (product == null)
                {
                    continue;
                }

                foreach (var marketProduct in product.MarketProducts)
                {
                    var marketName = marketProduct.Market.Name;
                    var productCostInMarket = marketProduct.Price * tempItem.Amount;

                    if (result.ContainsKey(marketName))
                    {
                        result[marketName] += productCostInMarket;
                    }
                    else
                    {
                        result[marketName] = productCostInMarket;
                    }
                }
            }

            return result;
        }



        public async Task<(TempShoppingListDto, Dictionary<string, double>)> GetTemporaryShoppingListWithCostsAsync(string uniqueToken)
        {
            var cacheKey = $"TempShoppingList_{uniqueToken}";

            if (!_cache.TryGetValue(cacheKey, out List<ProductShoppingList> tempList))
            {
                // Wenn keine Liste im Cache vorhanden ist, gib eine leere Liste zurück
                return (new TempShoppingListDto { Items = new List<TempProductItemDto>() }, new Dictionary<string, double>());
            }

            // Filtere Einträge mit null ProductId heraus
            var filteredTempList = tempList.Where(psl => psl.ProductId.HasValue).ToList();

            // Konvertiere die gefilterte Liste in TempShoppingListDto
            var tempListDto = new TempShoppingListDto
            {
                Items = filteredTempList.Select(psl => new TempProductItemDto { ProductId = psl.ProductId.Value, Amount = psl.Amount }).ToList()
            };

            var marketCosts = await CalculateCostsPerMarketAsync(filteredTempList);
            return (tempListDto, marketCosts);
        }


    }
}
