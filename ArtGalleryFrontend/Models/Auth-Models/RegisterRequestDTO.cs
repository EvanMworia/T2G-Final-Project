using System.ComponentModel.DataAnnotations;

namespace ArtGalleryFrontend.Models.Auth_Models
{
    public class RegisterRequestDTO
    {
        [Required]
        public string FullNames {  get; set; }=string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; }=string.Empty;
        [Required]
        public string PhysicalAddress { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
