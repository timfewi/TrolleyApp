using System.ComponentModel.DataAnnotations.Schema;
using Trolley.API.Entities;
using Trolley.API.Enums;

namespace Trolley.API.Entities
{
    [Table(nameof(Market))]
    public class Market : BaseEntity
    {
        public string Name { get; set; }
        public bool? IsNearest { get; set; }
        public MarketCategory Category { get; set; }

        // Navigation properties
        public ICollection<MarketProductPrice> MarketProductPrices { get; set; }

    }
}
