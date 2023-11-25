using System.ComponentModel.DataAnnotations.Schema;
using Trolley.API.Entities;

namespace Trolley.API.Entities
{
    [Table(nameof(Product))]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsOrganic { get; set; }
        public bool IsAvailable { get; set; }



        // Navigation Properties

        public virtual Guid ProductCategoryId { get; set; }
        public virtual Guid BrandId { get; set; }
        public virtual Guid ShoppingListId { get; set; }
        public virtual Guid MarketsId { get; set; }
        public virtual Guid PricesId { get; set; }

        public Category Category { get; set; }

        public ICollection<Market> Markets { get; set; }
        public ICollection<Price> Prices { get; set; }
        public ICollection<Brand> Brands { get; set; }
        public ICollection<ShoppingList> ShoppingLists { get; set; }
        public ICollection<BrandProduct> BrandProducts { get; set; }
        public ICollection<ProductShoppingList> ProductShoppingLists { get; set; }
        public ICollection<MarketProductPrice> MarketProductPrices { get; set; }
    }
}
