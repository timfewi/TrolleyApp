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


        public async Task<ShoppingList> GetShoppingListByIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
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


        public async Task DeleteShoppingListAsync(Guid id)
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


    }
}
