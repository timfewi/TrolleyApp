using Microsoft.AspNetCore.Identity;

namespace Trolley.API.Entities
{
    public class User : BaseEntity
    {

        // Properties

        // Navigation Properties


        public ICollection<ShoppingListUser> ShoppingListUsers { get; set; }
    }
}
