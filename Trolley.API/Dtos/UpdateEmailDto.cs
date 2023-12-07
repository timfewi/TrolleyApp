using System.ComponentModel.DataAnnotations;

namespace Trolley.API.Dtos
{
    public class UpdateEmailDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string NewEmail { get; set; }
    }
}
