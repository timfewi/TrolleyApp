using System.ComponentModel.DataAnnotations.Schema;
using Trolley.API.Entities;

namespace Trolley.API.Entities
{
    [Table(nameof(MarketProductPrice))]
    public class MarketProductPrice
    {


        // Navigation Properties

        public Guid PriceId { get; set; }
        public virtual Price Price { get; set; }

        public Guid MarketId { get; set; }
        public virtual Market Market { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
