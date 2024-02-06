using System.ComponentModel.DataAnnotations;

namespace ArtGalleryFrontend.Models.Auth_Models
{
    public class UserDTO
    {
        
        public Guid Id { get; set; }
        public string FullNames { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;
        public string? Role { get; set; } = "Bidder";





    }
}
