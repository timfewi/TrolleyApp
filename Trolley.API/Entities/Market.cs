using System.ComponentModel.DataAnnotations.Schema;
using Trolley.API.Entities;
using Trolley.API.Enums;

namespace Trolley.API.Entities
{
    [Table(nameof(Market))]
    public class Market : BaseEntity
    {
        public string Name { get; set; }
        public MarketCategory MarketCategory { get; set; }

        // Navigation properties
        public ICollection<MarketProduct> MarketProduct { get; set; }

    }
}
