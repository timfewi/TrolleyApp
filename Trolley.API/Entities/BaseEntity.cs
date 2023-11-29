using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Trolley.API.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
