using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trolley.API.Entities;
using Trolley.API.Data;
using Trolley.API.Dtos;

namespace Trolley.API.Services
{
    public class ShoppingListService : BaseService
    {

        public ShoppingListService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<ShoppingList> CreateShoppingListAsync(ShoppingList shoppingList)
        {
            _context.ShoppingLists.Add(shoppingList);
            await _context.SaveChangesAsync();
            return shoppingList;
        }


        public async Task<ShoppingList> GetShoppingListByIdAsync(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception($"Couldn't find shopping list with id: {id}");

                }
                else
                {
                    var shoppingLists = await _context.ShoppingLists
                        .Include(sl => sl.UserShoppingLists)
                        .ThenInclude(slu => slu.AppUser)
                        .Include(sl => sl.ProductShoppingLists)
                        .ThenInclude(sli => sli.Product)
                        .FirstOrDefaultAsync(sl => sl.Id == id);
                    return shoppingLists;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't find shopping list with id: {id}", ex);
            }
        }

        public async Task<ShoppingList> UpdateShoppingListAsync(ShoppingList shoppingList)
        {
            try
            {
                _context.ShoppingLists.Update(shoppingList);
                await _context.SaveChangesAsync();
                return shoppingList;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't update shopping list with id: {shoppingList.Id}", ex);
            }
        }


        public async Task DeleteShoppingListAsync(int id)
        {
            try
            {
                var shoppingList = await _context.ShoppingLists.FindAsync(id);
                if (shoppingList != null)
                {
                    _context.ShoppingLists.Remove(shoppingList);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't delete shopping list with id: {id}", ex);
            }
        }



        public async Task<bool> AddProductToShoppingListAsync(int shoppingListId, int productId, int amount)
        {
            var shoppingList = await _context.ShoppingLists
                .Include(sl => sl.ProductShoppingLists)
                .FirstOrDefaultAsync(sl => sl.Id == shoppingListId);

            if (shoppingList == null)
            {
                throw new KeyNotFoundException($"Couldn't find shopping list with id: {shoppingListId}");
            }

            var productShoppingList = new ProductShoppingList
            {
                ProductId = productId,
                ShoppingListId = shoppingListId,
                Amount = amount
            };

            shoppingList.ProductShoppingLists.Add(productShoppingList);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ShoppingListReadDto> GetShoppingListWithCalculationsAsync(int id)
        {
            var shoppingList = await GetShoppingListByIdAsync(id);
            if (shoppingList == null)
            {
                throw new KeyNotFoundException($"Couldn't find shopping list with id: {id}");
            }

            var shoppingListDto = _mapper.Map<ShoppingListReadDto>(shoppingList);

            shoppingListDto.TotalPrice = CalculateTotalCost(shoppingList).Result;
            shoppingListDto.CostPerMarket = CalculateCostPerMarket(shoppingList).Result;

            return shoppingListDto;
        }

        public async Task<KeyValuePair<string, double>> CalculateCheapestMarketForShoppingListAsync(int shoppingListId)
        {
            var shoppingList = await GetShoppingListByIdAsync(shoppingListId);
            if (shoppingList == null)
            {
                throw new KeyNotFoundException($"Einkaufsliste mit ID {shoppingListId} nicht gefunden.");
            }

            var costPerMarket = await CalculateCostPerMarket(shoppingList);
            return FindCheapestMarket(costPerMarket);
        }




        #region Logic for ShoppingListReadDto calculations
        private async Task<Double> CalculateTotalCost(ShoppingList shoppingList)
        {
            var result = 0.0;

            // Sammle alle Produkt-IDs aus der Einkaufsliste
            var productIds = shoppingList.ProductShoppingLists.Select(psl => psl.ProductId).ToList();

            // Hole alle Marktpreise für diese Produkte in einer Abfrage
            var marketProducts = await _context.MarketProduct
                .Include(mp => mp.Market)
                .Where(mp => productIds.Contains(mp.ProductId))
                .ToListAsync();

            foreach (var productShoppingList in shoppingList.ProductShoppingLists)
            {
                // Finde die zugehörigen Marktpreise für jedes Produkt
                var relevantMarketProducts = marketProducts.Where(mp => mp.ProductId == productShoppingList.ProductId);

                foreach (var marketProduct in relevantMarketProducts)
                {
                    result += marketProduct.Price * productShoppingList.Amount;
                }
            }

            return result;
        }

        private async Task<Dictionary<string, double>> CalculateCostPerMarket(ShoppingList shoppingList)
        {
            var result = new Dictionary<string, double>();

            // Sammle alle Produkt-IDs aus der Einkaufsliste
            var productIds = shoppingList.ProductShoppingLists.Select(psl => psl.ProductId).ToList();

            // Hole alle Marktpreise für diese Produkte in einer Abfrage
            var marketProducts = await _context.MarketProduct
                .Include(mp => mp.Market)
                .Where(mp => productIds.Contains(mp.ProductId))
                .ToListAsync();

            foreach (var productShoppingList in shoppingList.ProductShoppingLists)
            {
                // Finde die zugehörigen Marktpreise für jedes Produkt
                var relevantMarketProducts = marketProducts.Where(mp => mp.ProductId == productShoppingList.ProductId);

                foreach (var marketProduct in relevantMarketProducts)
                {
                    if (result.ContainsKey(marketProduct.Market.Name))
                    {
                        result[marketProduct.Market.Name] += marketProduct.Price * productShoppingList.Amount;
                    }
                    else
                    {
                        result.Add(marketProduct.Market.Name, marketProduct.Price * productShoppingList.Amount);
                    }
                }
            }

            return result;
        }



        private KeyValuePair<string, double> FindCheapestMarket(Dictionary<string, double> costPerMarket)
        {
            if (costPerMarket == null || costPerMarket.Count == 0)
            {
                throw new InvalidOperationException("Keine Marktkosten verfügbar für die Berechnung.");
            }
            var cheapestMarket = costPerMarket.Aggregate((l, r) => l.Value < r.Value ? l : r);
            return cheapestMarket;
        }


        #endregion


    }
}
