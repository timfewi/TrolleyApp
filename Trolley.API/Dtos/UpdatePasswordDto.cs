using System.ComponentModel.DataAnnotations;

namespace Trolley.API.Dtos
{
    public class UpdatePasswordDto
    {
        [Required]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Das {0} muss mindestens {2} und maximal {1} Zeichen lang sein.", MinimumLength = 6)]
        public string NewPassword { get; set; }
    }
}
