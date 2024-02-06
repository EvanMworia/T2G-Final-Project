using System.ComponentModel.DataAnnotations;

namespace ArtGalleryFrontend.Models.Auth_Models
{
    public class RegisterRequestDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty; //might comment this out later

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;


        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        public string? Role { get; set; } = "Bidder";

    }
}
