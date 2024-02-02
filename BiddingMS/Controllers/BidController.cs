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
        private readonly IProduct _productService;
        private readonly ResponseDTO _responseDTO;
        public BidController(IBidding bidding, IProduct productService)
        {
            _bidService = bidding;
            _responseDTO = new ResponseDTO();
            _productService = productService;
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> PlaceBid(AddBidDTO dto)
        {
            //Checking if user is logged in by checking the token issued and the one supplied by the user
            string bidderId = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)?.Value;
            if (bidderId==null)
            {
                _responseDTO.Message = "You need to be logged in to perfom that action";
                return BadRequest( _responseDTO);
            }

            /*            1 > check if product exist:--
                            if (product does not exists):--
                               return product not found--
                           if dto.BidAmont<= product.HighestBid:
                                    return bid higher
                          var highestBid =   new HighestBid() {
            amount = dto.HighestBid
                            };
               // update product highest bid
                _productsService.updateHighestBid(dto.productId, highestBid)

            */
            var productResult = await _productService.GetProductById(dto.PieceId);
            if (productResult.ArtPiece == null)
            {
                _responseDTO.Message = productResult.ErrorMessage;
                return BadRequest( _responseDTO);
            }
            if (dto.Price <= productResult.ArtPiece.HighestBid)
            {
                _responseDTO.Message = "Can Not bid lower than the already existing bid. Bid Higher";
                return BadRequest(_responseDTO);
            }
            var highestBid = new HighestBid() 
            { 
                amount = dto.Price 
            };
            await _productService.CheckHighestBid(dto.PieceId, highestBid);

            //----
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
