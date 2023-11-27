using Trolley.API.Dtos;
using Trolley.API.Entities;

namespace Trolley.API.Services
{
    public interface IShoppingListService
    {
        Task<ShoppingList> CreateShoppingListAsync(ShoppingList shoppingList);
        Task<ShoppingList> GetShoppingListByIdAsync(Guid id);
        Task<ShoppingList> UpdateShoppingListAsync(ShoppingList shoppingList);
        Task DeleteShoppingListAsync(Guid id);
    }
}
