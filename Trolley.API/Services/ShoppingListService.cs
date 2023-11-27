using Microsoft.EntityFrameworkCore;
using Trolley.API.Entities;
using Trolley.Domain.Data;

namespace Trolley.API.Services
{
    public class ShoppingListService : BaseService
    {

        public ShoppingListService(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public async Task<ShoppingList> GetShoppingListByIdAsync(Guid id)
        {
            var shoppingList = await _context.ShoppingLists
                .Include(s => s.ProductShoppingLists)
                .ThenInclude(psl => psl.Product)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (shoppingList == null)
            {
                return null;
            }


            if (shoppingList.ProductShoppingLists != null)
            {
                foreach (var psl in shoppingList.ProductShoppingLists)
                {

                    if (psl.Product == null)
                    {
                        psl.Product = await _context.Products.FirstOrDefaultAsync(p => p.Id == psl.ProductId);
                    }
                }
            }

            return shoppingList;
        }

    }
}
