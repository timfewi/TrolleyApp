using System.ComponentModel.DataAnnotations.Schema;

namespace Trolley.API.Entities
{
    [Table(nameof(Price))]
    public class Price : BaseEntity
    {
        public double Amount { get; set; }
        public double? Reduction { get; set; }

        public new DateTime PriceTimestamp { get; set; }

        // Navigation properties
        public ICollection<MarketProductPrice> MarketProductPrices { get; set; }

    }
}
