using BiddingMS.Models.DTOs;



namespace BiddingMS.Services.IService
{
    public interface IProduct
    {
        Task<ArtPieceResponseDto> GetProductById(Guid productId);
        Task<ResponseDTO> GetAllProducts();
        Task CheckHighestBid(Guid productId, HighestBid highestBid);
    }
}
