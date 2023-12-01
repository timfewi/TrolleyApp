using Microsoft.AspNetCore.Identity;

namespace Trolley.API.Entities
{
    public class AppUser : IdentityUser
    {
        public virtual ICollection<UserShoppingList> UserShoppingLists { get; set; }
        public virtual ICollection<BlockedMarket> BlockedMarkets { get; set; }

    }
}
