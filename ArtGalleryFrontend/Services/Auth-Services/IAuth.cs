using ArtGalleryFrontend.Models;
using ArtGalleryFrontend.Models.Auth_Models;

namespace ArtGalleryFrontend.Services.AuthServices
{
    public interface IAuth
    {
        Task<ResponseDTO> Register(RegisterRequestDTO registerRequestDto);

        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto);
    }
}
