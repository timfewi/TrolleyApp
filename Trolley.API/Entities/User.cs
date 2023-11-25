using System.ComponentModel.DataAnnotations.Schema;
using Trolley.API.Enums;

namespace Trolley.API.Entities
{
    [Table(nameof(User))]
    public class User : BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRoles Role { get; set; }
        public string Token { get; set; }


        // Navigation Properties
        public ICollection<ShoppingListUser> ShoppingListUsers { get; set; }
    }
}
