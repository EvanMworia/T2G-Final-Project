using BiddingMS.Models.DTOs;

namespace BiddingMS.Services.IService
{
    public interface IBidding
    {
        public Task<ResponseDTO> PlaceBid(AddBidDTO bidDTO);
        public Task<ResponseDTO> GetAllBids();
        public Task<ResponseDTO> GetBidById(Guid Id);

    }
}
