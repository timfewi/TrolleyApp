using Microsoft.AspNetCore.Identity;

namespace Trolley.API.Entities
{
    public class User : BaseEntity
    {

        // Properties

        // Navigation Properties

        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public ICollection<ShoppingListUser> ShoppingListUsers { get; set; }
    }
}
