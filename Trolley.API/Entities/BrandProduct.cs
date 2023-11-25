using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Trolley.API.Entities;

namespace Trolley.API.Entities
{

    [Table(nameof(BrandProduct))]
    public class BrandProduct
    {
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
