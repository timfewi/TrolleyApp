using Microsoft.EntityFrameworkCore;
using Trolley.API.Entities;
using Trolley.API.Data;

namespace Trolley.API.Services
{
    public class ShoppingListService : BaseService, IShoppingListService
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
                        .Include(sl => sl.ShoppingListUsers)
                        .ThenInclude(slu => slu.User)
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

        public async Task AddProductToShoppingListAsync(int shoppingListId, int productId)
        {
            var shoppingList = await _context.ShoppingLists.FindAsync(shoppingListId);
            var product = await _context.Products.FindAsync(productId);

            if (shoppingList == null || product == null)
            {
                throw new KeyNotFoundException(
                    $"Couldn't find shopping list with id: {shoppingListId} or product with id: {productId}");
            }

            var productShoppingList = new ProductShoppingList
            {
                ProductId = productId,
                ShoppingListId = shoppingListId
            };

            _context.ProductShoppingLists.Add(productShoppingList);
            await _context.SaveChangesAsync();
        }

        public Task<Market> CalculateShoppingListTotalPriceAsync(int shoppingListId)
        {
            throw new NotImplementedException();
        }

        public Task<Market> CheapestMarketForShoppingListAsync(int shoppingListId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProductFromShoppingListAsync(int shoppingListId, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
