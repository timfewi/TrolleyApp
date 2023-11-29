using System.ComponentModel.DataAnnotations.Schema;

namespace Trolley.API.Entities
{
    [Table(nameof(ProductCategory))]
    public class ProductCategory : BaseEntity
    {
        public string Name { get; set; }

    }
}
