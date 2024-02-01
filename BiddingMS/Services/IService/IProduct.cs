using BiddingMS.Models.DTOs;

namespace BiddingMS.Services.IService
{
    public interface IProduct
    {
        Task<ResponseDTO> GetProductById();
        Task<ResponseDTO> GetAllProducts(Guid productId);
    }
}
