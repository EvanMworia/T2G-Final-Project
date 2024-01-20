using System.ComponentModel.DataAnnotations;

namespace ArtGalleryFrontend.Models.Auth_Models
{
    public class LoginRequestDTO
    {
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
