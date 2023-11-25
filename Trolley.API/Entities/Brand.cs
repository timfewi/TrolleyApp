using System.ComponentModel.DataAnnotations.Schema;

namespace Trolley.API.Entities
{
    [Table(nameof(Brand))]
    public class Brand : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<BrandProduct> BrandProducts { get; set; }
    }
}
