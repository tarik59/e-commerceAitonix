﻿using System.ComponentModel.DataAnnotations;

namespace Application.Contracts
{
    public class RegisterDto
    {

        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string UserName { get; set; }
        [StringLength(30, MinimumLength = 5)]
        [Required]
        public string Password { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
