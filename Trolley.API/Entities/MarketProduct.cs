using System.ComponentModel.DataAnnotations.Schema;
using Trolley.API.Entities;

namespace Trolley.API.Entities
{
    [Table(nameof(MarketProduct))]
    public class MarketProduct : BaseEntity
    {

        public double Price { get; set; }
        public int MarketId { get; set; }
        public virtual Market Market { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
