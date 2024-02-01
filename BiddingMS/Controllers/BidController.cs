using BiddingMS.Models.DTOs;
using BiddingMS.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> PlaceBid(AddBidDTO dto)
        {
            string bidderId = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
            if (bidderId==null)
            {
                _responseDTO.Message = "You need to be logged in to perfom that action";
                return BadRequest( _responseDTO);
            }
            var result = await _bidService.PlaceBid(dto);
            
            return Ok(result);

        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> GetAllBids()
        {
            var list = await _bidService.GetAllBids();
            return Ok(list);
        }
        [HttpGet("Single/{Id}")]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> GetBidById(Guid Id)
        {
            var result = await _bidService.GetBidById(Id);
            return result;

        }
    }
}
