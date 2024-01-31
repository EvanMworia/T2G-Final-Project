using AutoMapper;
using BiddingMS.Models;
using BiddingMS.Models.DTOs;

namespace BiddingMS.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<AddBidDTO, Bid>();
        }
    }
}
