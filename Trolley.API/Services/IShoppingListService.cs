using Trolley.API.Dtos;
using Trolley.API.Entities;

namespace Trolley.API.Services
{
    public interface IShoppingListService
    {
        Task<ShoppingList> CreateShoppingListAsync(ShoppingList shoppingList);
        Task<ShoppingList> GetShoppingListByIdAsync(int id);
        Task<ShoppingList> UpdateShoppingListAsync(ShoppingList shoppingList);
        Task DeleteShoppingListAsync(int id);
        Task AddProductToShoppingListAsync(int shoppingListId, int productId);
        Task<Market> CalculateShoppingListTotalPriceAsync(int shoppingListId);
        Task<Market> CheapestMarketForShoppingListAsync(int shoppingListId);
        Task RemoveProductFromShoppingListAsync(int shoppingListId, int productId);

    }
}
