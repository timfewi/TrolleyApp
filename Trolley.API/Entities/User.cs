using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Trolley.API.Enums;

namespace Trolley.API.Entities
{
    [Table(nameof(User))]
    public class User : IdentityUser<int>
    {
        //User erbt von IdentityUser<int> und bekommt dadurch
        //die Properties Id,
        //UserName, Email, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber,
        //PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CreatedBy { get; set; }
        // End Base Properties

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRoles Role { get; set; }
        public string AccessToken { get; set; }




        // Navigation Properties
        public ICollection<ShoppingListUser> ShoppingListUsers { get; set; }
    }
}
