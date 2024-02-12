using ArtProducts.Models;
using ArtProducts.Models.DTOs;
using BiddingMS.Models.DTOs;

namespace ArtProducts.Services.IServices
{
    public interface IProducts
    {
        Task<ResponseDTO> AddArtProduct(ArtPiece addPieceDTO);
        Task<ArtPiece> GetArtPieceById(Guid id);
        Task<List<ArtPiece>> GetAllArtPieces();
        Task<string> DeleteArtPiece(ArtPiece piece);
        Task<bool> UpdateHighestBid(Guid productId, double amount);
    }
}
