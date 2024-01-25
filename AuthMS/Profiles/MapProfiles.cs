using AuthMS.Models;
using AuthMS.Models.DTOs;
using AutoMapper;

namespace AuthMS.Profiles
{
    public class MapProfiles:Profile
    {
        public MapProfiles()
        {
            CreateMap<RegisterUserDTO, AppUser>();

            CreateMap<AppUser, UserDTO>().ReverseMap();
        }
    }
}
