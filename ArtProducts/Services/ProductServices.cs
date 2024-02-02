using ArtProducts.Database;
using ArtProducts.Models;
using ArtProducts.Models.DTOs;
using ArtProducts.Services.IServices;
using AutoMapper;
using BiddingMS.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ArtProducts.Services
{

    public class ProductServices : IProducts
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ResponseDTO _responseDTO;
        public ProductServices(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _context = applicationDbContext;
            _mapper = mapper;
            _responseDTO= new ResponseDTO();
        }


        public async Task<ResponseDTO> AddArtProduct(AddArtPieceDTO addPieceDTO)
        {
            try
            {
                var artPiece = _mapper.Map<ArtPiece>(addPieceDTO);
                artPiece.HighestBid = addPieceDTO.StartBidPrice;
                 _context.ArtPieces.Add(artPiece);
                await _context.SaveChangesAsync();
                _responseDTO.Message = "Art Piece Added Successfully";
                _responseDTO.Result = artPiece;
                _responseDTO.isSuccess = true;
                return _responseDTO;
            }
            catch (Exception ex) 
            {
                _responseDTO.Message = ex.Message;
                return _responseDTO;
            }
            


        }

        public async Task<string> DeleteArtPiece(ArtPiece piece)
        {
             _context.ArtPieces.Remove(piece);
            await _context.SaveChangesAsync();
            return "Piece Deleted successfully";
        }

        public async Task<List<ArtPiece>> GetAllArtPieces()
        {
            return await _context.ArtPieces.ToListAsync();
            
        }

        public async Task<ArtPiece> GetArtPieceById(Guid id)
        {
            return await _context.ArtPieces.Where(x=> x.PieceId == id).FirstOrDefaultAsync();

        }

        public async Task<bool> UpdateHighestBid(Guid productId,double amount)
        {
           ArtPiece artPiece = await GetArtPieceById(productId);
            if (artPiece!=null)
            {
                artPiece.HighestBid = amount;
                await _context.SaveChangesAsync();
                return true;  
            }
                return false;

        }

        
    }
}
