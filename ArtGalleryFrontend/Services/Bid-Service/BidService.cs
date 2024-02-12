using ArtGalleryFrontend.Models;
using ArtGalleryFrontend.Models.ArtProducts;
using ArtGalleryFrontend.Models.Bid_Models;
using ArtGalleryFrontend.Models.Bid_Models.DTOs;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ArtGalleryFrontend.Services.Bid_Service
{
    public class BidService : IBid
    {
        private HttpClient _httpClient;
        private string BASEURL = "https://localhost:7258";
        public BidService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            
        }
        public async Task <List<Bid>> GetAllBids()
        {
            var response = await _httpClient.GetAsync($"{BASEURL}/api/Bid");
            var content = await response.Content.ReadAsStringAsync();


            var results = JsonConvert.DeserializeObject<ResponseDTO>(content);

            if (results.IsSuccess)
            {

                return JsonConvert.DeserializeObject<List<Bid>>(results.Result.ToString());

            }
            return new List<Bid>();
        }

        public async Task<Bid> GetBidById(Guid Id)
        {
            var response = await _httpClient.GetAsync($"{BASEURL}/api/Bid/Single/{Id}");
            var content = await response.Content.ReadAsStringAsync();

            var results = JsonConvert.DeserializeObject<ResponseDTO>(content);

            if (results.IsSuccess)
            {
                //change this to a list of products
                return JsonConvert.DeserializeObject<Bid>(results.Result.ToString());

            }
            return new Bid();
        }

        public async Task<ResponseDTO> PlaceBid(AddBidDTO bidDTO)
        {
            var request = JsonConvert.SerializeObject(bidDTO);
            var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{BASEURL}/api/Bid/", bodyContent);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDTO>(content);
            return result;
        }
    }
}
