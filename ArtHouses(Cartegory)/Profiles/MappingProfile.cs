using ArtHouses_Cartegory_.Models;
using ArtHouses_Cartegory_.Models.DTOs;
using AutoMapper;

namespace ArtHouses_Cartegory_.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
            
        }
    }
}
