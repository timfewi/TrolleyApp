﻿using System.ComponentModel.DataAnnotations;
using Trolley.API.Enums;

namespace Trolley.API.Dtos
{
    public class RegisterRequestDto
    {


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password has to be a minimum of 6 characters")]
        [MaxLength(20, ErrorMessage = "Password has to be a max of  20 Characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //public string[] Roles { get; set; }
    }
}
