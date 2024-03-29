﻿using System.ComponentModel.DataAnnotations;

namespace AuthMS.Models.DTOs
{
    public class RegisterUserDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        public string? Role { get; set; } = "User";
    }
}
