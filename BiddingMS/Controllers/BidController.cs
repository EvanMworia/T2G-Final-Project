using BiddingMS.Models.DTOs;
using BiddingMS.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiddingMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidding _bidService;
        private readonly ResponseDTO _responseDTO;
        public BidController(IBidding bidding)
        {
            _bidService = bidding;
            _responseDTO = new ResponseDTO();
        }
        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> PlaceBid(AddBidDTO dto)
        {
           var result = await _bidService.PlaceBid(dto);
            
            return Ok(result);

        }
        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAllBids()
        {
            var list = await _bidService.GetAllBids();
            return Ok(list);
        }
        [HttpGet("Single/{Id}")]
        public async Task<ActionResult<ResponseDTO>> GetBidById(Guid Id)
        {
            var result = await _bidService.GetBidById(Id);
            return result;

        }
    }
}
