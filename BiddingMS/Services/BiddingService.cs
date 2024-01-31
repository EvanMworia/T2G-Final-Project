using AutoMapper;
using BiddingMS.Data;
using BiddingMS.Models;
using BiddingMS.Models.DTOs;
using BiddingMS.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace BiddingMS.Services
{
    public class BiddingService : IBidding
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly ResponseDTO _responseDTO;
        public BiddingService(IMapper mapper,ApplicationDbContext applicationDbContext)
        {
            _mapper = mapper;
            _context = applicationDbContext;
            _responseDTO= new ResponseDTO();
            
        }

        public async Task<ResponseDTO> GetBidById(Guid Id)
        {
            var result = await _context.Bids.Where(x=> x.BidId==Id).FirstOrDefaultAsync();
            if (result==null)
            {
                _responseDTO.Message = "We couldn't find a bid with that Id, Check and try again!!";
                _responseDTO.Result = null;
                return _responseDTO;
            }
            _responseDTO.Message = "Here is what we found based on the Id you entered";
            _responseDTO.Result = result;
            return _responseDTO;
        }

        public async Task<ResponseDTO> GetAllBids()
        {
            var bids = await _context.Bids.ToListAsync();
            if (bids==null)
            {
                _responseDTO.Message = "No Bid Has been placed yet!";
                _responseDTO.Result = new ResponseDTO();
                return _responseDTO;
            }
            _responseDTO.Message = "Here is what we found";
            _responseDTO.Result = bids;
            return _responseDTO;
        }
        public async Task<ResponseDTO> PlaceBid(AddBidDTO bidDTO)
        {
            var mappedBid = _mapper.Map<Bid>(bidDTO);
            await _context.Bids.AddAsync(mappedBid);
            await _context.SaveChangesAsync();
            _responseDTO.Message = "Bid Has been placed Successfully";
            _responseDTO.Result= mappedBid;
            return _responseDTO;
        }
    }
}
