using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trolley.DataSeeder.Data
{

    public static class ProductGenerator
    {

    }


    public class ProductTemplate
    {

        public string Name { get; set; }
        public bool IsOrganic { get; set; }
        public bool IsBrandedProduct { get; set; }
        public Guid ProductCategoryId { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? ShoppingListId { get; set; }
        public Guid MarketsId { get; set; }
        public Guid PricesId { get; set; }

    }
}
