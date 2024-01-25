using AuthMS.Data;
using AuthMS.Models;
using AuthMS.Models.DTOs;
using AuthMS.Services.Iservices;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthMS.Services
{
    public class AuthService : IAuth
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(ApplicationDbContext context, IMapper mapper, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public Task<AppUser> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<LoginResponseDTO> LoginUser(LoginRequestDTO loginrequestdto)
        {
            throw new NotImplementedException();
        }

        public async Task<string> RegisterUser(RegisterUserDTO registerdto)
        {
            try
            {

                var user = _mapper.Map<AppUser>(registerdto);
                var result = await _userManager.CreateAsync(user, registerdto.Password);
                if(result.Succeeded)
                {
                    return string.Empty;
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
    }
}
