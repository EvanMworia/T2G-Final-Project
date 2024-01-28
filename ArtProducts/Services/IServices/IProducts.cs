using ArtProducts.Models;
using ArtProducts.Models.DTOs;

namespace ArtProducts.Services.IServices
{
    public interface IProducts
    {
        Task<ResponseDTO> AddArtProduct(AddArtPieceDTO addPieceDTO);
        Task<ArtPiece> GetArtPieceById(Guid id);
        Task<List<ArtPiece>> GetAllArtPieces();
        Task<string> DeleteArtPiece(ArtPiece piece);
    }
}
