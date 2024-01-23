using System.ComponentModel.DataAnnotations;

namespace ArtGalleryFrontend.Models.Auth_Models
{
    public class UserDTO
    {
        // rudisha guid - int ni example
        public int Id { get; set; }
        public string FullNames { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
        
    }
}
