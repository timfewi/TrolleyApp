using Microsoft.AspNetCore.Identity;

namespace Trolley.API.Entities
{
    public class BlockedMarket
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int MarketId { get; set; }
        public Market Market { get; set; }

    }
}
