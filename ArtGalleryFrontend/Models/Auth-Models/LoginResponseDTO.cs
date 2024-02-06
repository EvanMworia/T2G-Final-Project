namespace ArtGalleryFrontend.Models.Auth_Models
{
    public class LoginResponseDTO
    {
        public string Token { get; set; } = string.Empty;

        public UserDTO User { get; set; } = default!;
    }
}
