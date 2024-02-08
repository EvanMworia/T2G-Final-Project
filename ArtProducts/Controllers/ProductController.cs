using ArtProducts.Models;
using ArtProducts.Models.DTOs;
using ArtProducts.Services.IServices;
using AutoMapper;
using BiddingMS.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProducts _products;
        private readonly ResponseDTO _response;
        private readonly IMapper _mapper;

        public ProductController(IProducts products, IMapper mapper)
        {
            _products = products;
            _mapper = mapper;
            _response = new ResponseDTO();
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> RegisterPiece(AddArtPieceDTO artPieceDTO)
        { 
            var response = await _products.AddArtProduct(artPieceDTO);
           
            return Created("", response);
        }
        [HttpGet("SingleProduct/{ProductId}")]
        /*[Authorize]*/
        public async Task<ActionResult<ResponseDTO>> GetSingleProduct(Guid ProductId)
        {
            var result = await _products.GetArtPieceById(ProductId);
            var mappedItem = _mapper.Map<ArtPieceDisplayDTO>(result);
            if (result!=null)
            {
                _response.Message = "This Is what you're looking for";
                _response.Result = mappedItem;
                _response.isSuccess = true;
                return Ok(_response);

            }
            _response.Message = "Product Not Found";
            return NotFound(_response);
        }
       
        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAllProducts()
        {
            var products = await _products.GetAllArtPieces();
            _response.Message = "This is what was found";
            _response.isSuccess = true;
            _response.Result = products;
            return Ok(_response);
        }
        [HttpPut("{Id}")]
        
        public async Task<ActionResult<ResponseDTO>> UpdateHighestBid(Guid Id, HighestBid highestBid)
        {
            bool isSuccess =await _products.UpdateHighestBid(Id, highestBid.amount);
            if (isSuccess) {
                _response.Message = "Product Highest Bid Updated Successfully";
            return Ok(_response);
            } 
            _response.Message = "Product not found";
            return NotFound(_response);
        }
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<ResponseDTO>> DeleteProduct(Guid ProductId)
        {
            var result = await _products.GetArtPieceById(ProductId);
            if (result == null)
            {
                _response.Result = "No Product was found associated with that ID";
                return NotFound(_response);

            }
            var returnValue = await _products.DeleteArtPiece(result);
            _response.Result = returnValue;
            _response.isSuccess = true;
            return Ok(_response);

        }
    }
}
