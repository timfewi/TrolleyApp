using System.Runtime.CompilerServices;
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

        public TemporaryShoppingListService(IServiceProvider serviceProvider, IMemoryCache cache) : base(
            serviceProvider)
        {
            _cache = cache;
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


        public async Task<List<TempMarketCostDto>> AddProductAndCalculateCostsPerMarketAsync(
            List<TempProductItemDto> productListDto)
        {
            var tempList = productListDto
                .Select(p => new ProductShoppingList { ProductId = p.ProductId, Amount = p.Amount })
                .ToList();

            var marketCosts = await CalculateCostsPerMarketAsync(tempList);
            return marketCosts.Select(mc => new TempMarketCostDto { MarketName = mc.Key, TotalPrice = mc.Value })
                .ToList();
        }


        public async Task<ConvertedShoppingListDtoResponse> ConvertTemplistToPermanentListAsync(List<TempProductItemDto> tempProductItemDtos, string userId)
        {
            try
            {
                var shoppingList = new ShoppingList
                {
                    Name = "Personal List",
                    UserShoppingLists = new List<UserShoppingList>
                    {
                        new UserShoppingList { AppUserId = userId }
                    },
                    ProductShoppingLists = tempProductItemDtos.Select(p => new ProductShoppingList
                    {
                        ProductId = p.ProductId,
                        Amount = p.Amount
                    }).ToList()
                };

                _context.ShoppingLists.Add(shoppingList);
                await _context.SaveChangesAsync();

                var marketCosts = await CalculateCostsPerMarketAsync(shoppingList.ProductShoppingLists.ToList());


                return new ConvertedShoppingListDtoResponse
                {
                    Id = shoppingList.Id,
                    Name = shoppingList.Name,
                    CostPerMarket = marketCosts,
                    DateCreated = shoppingList.DateCreated,
                    DateModified = shoppingList.DateModified
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fehler beim Konvertieren der temporären Liste in eine permanente Liste für Benutzer {UserId}", userId);
                throw;
            }
        }




    }
}
