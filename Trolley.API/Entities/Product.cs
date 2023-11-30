using System.ComponentModel.DataAnnotations.Schema;
using Trolley.API.Entities;

namespace Trolley.API.Entities
{
    [Table(nameof(Product))]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public bool IsOrganic { get; set; }
        public bool IsDiscountProduct { get; set; }
        public virtual int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public string IconName { get; set; }

        public ICollection<ProductShoppingList> ProductShoppingLists { get; set; }
        public ICollection<BrandProduct> BrandProducts { get; set; }
        public ICollection<MarketProduct> MarketProducts { get; set; }


    }
}
