using ArtGalleryFrontend.Models;
using ArtGalleryFrontend.Models.ArtProducts;


namespace ArtGalleryFrontend.Services.ArtProduct_Services
{
    public interface IArt
    {
        Task<List<ArtDisplay>> GetArtsAsync();
        Task<ArtDto> GetArtByIdAsync(Guid id);
        Task<ResponseDTO> AddArt(AddArtPieceDTO art);
        Task<ResponseDTO> deleteArt(Guid id);
        Task<ResponseDTO> updateArt(Guid id, ArtRequestDto artRequestDto);
    }
}
