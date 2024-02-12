using ArtGalleryFrontend.Models.Bid_Models.DTOs;
using ArtGalleryFrontend.Models;
using ArtGalleryFrontend.Models.Bid_Models;
namespace ArtGalleryFrontend.Services.Bid_Service
{
    public interface IBid
    {
        public Task<ResponseDTO> PlaceBid(AddBidDTO bidDTO);
        public Task <List<Bid>> GetAllBids();
        public Task<Bid> GetBidById(Guid Id);
    }
}
