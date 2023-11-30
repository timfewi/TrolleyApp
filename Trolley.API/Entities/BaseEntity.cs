using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Trolley.API.Entities
{
    public class BaseEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Timestamp]
        [ConcurrencyCheck]
        public byte[] RowVersion { get; set; }

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public string? ModifiedBy { get; set; }
        public string? CreatedBy { get; set; }


    }
}
