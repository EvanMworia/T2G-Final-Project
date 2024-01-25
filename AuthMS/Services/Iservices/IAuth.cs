using AuthMS.Models;
using AuthMS.Models.DTOs;

namespace AuthMS.Services.Iservices
{
    public interface IAuth
    {
         Task<string> RegisterUser(RegisterUserDTO registerdto);
        Task<LoginResponseDTO> LoginUser(LoginRequestDTO loginrequestdto);
        Task<AppUser> GetUserById(string id);

    }
}
