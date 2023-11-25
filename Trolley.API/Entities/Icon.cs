using System.ComponentModel.DataAnnotations.Schema;

namespace Trolley.API.Entities
{
    [Table(nameof(Icon))]
    public class Icon : BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public virtual Category Category { get; set; }
    }
}
