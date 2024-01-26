using ArtProducts.Models;
using ArtProducts.Models.DTOs;
using AutoMapper;

namespace ArtProducts.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<AddArtPieceDTO, ArtPiece>().ReverseMap();
            CreateMap<ArtPiece, ArtPieceDisplayDTO>();
        }
    }
}
