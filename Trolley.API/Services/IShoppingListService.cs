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
        Task AddProductToShoppingListAsync(Guid shoppingListId, Guid productId);
        Task<Market> CalculateShoppingListTotalPriceAsync(Guid shoppingListId);
        Task<Market> CheapestMarketForShoppingListAsync(Guid shoppingListId);
        Task RemoveProductFromShoppingListAsync(Guid shoppingListId, Guid productId);

    }
}
