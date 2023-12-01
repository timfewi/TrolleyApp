using Microsoft.AspNetCore.Identity;

namespace Trolley.API.Entities
{
    public class UserShoppingList
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int ShoppingListId { get; set; }
        public ShoppingList ShoppingList { get; set; }
    }

}
