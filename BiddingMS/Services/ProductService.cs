
using BiddingMS.Models.DTOs;
using BiddingMS.Services.IService;

using Newtonsoft.Json;
using System.Text;

namespace BiddingMS.Services
{
    public class ProductService : IProduct
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ResponseDTO _responseDTO;
        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory;
            _responseDTO = new ResponseDTO();
        }

        public async Task<ResponseDTO> GetAllProducts()
        {
            var client = _httpClient.CreateClient("Product");
            var response = await client.GetAsync("");
            var content = await response.Content.ReadAsStringAsync();
            ResponseDTO productResponse = JsonConvert.DeserializeObject<ResponseDTO>(content);
            if (productResponse == null)
            {
                _responseDTO.Message = "Not found";
                _responseDTO.Result = productResponse;
                return _responseDTO;

            }
            return productResponse;
        }

        public async Task<ArtPieceResponseDto> GetProductById(Guid productId)
        {
            var client = _httpClient.CreateClient("Product");
            var response = await client.GetAsync($"SingleProduct/{productId}");
            var content = await response.Content.ReadAsStringAsync();
            ResponseDTO productResponse = JsonConvert.DeserializeObject<ResponseDTO>(content);
            if (response.IsSuccessStatusCode) {
                ArtPieceDTO artPiece = JsonConvert.DeserializeObject<ArtPieceDTO>(productResponse.Result.ToString());

                return new ArtPieceResponseDto() { ArtPiece = artPiece }; 
            }

           
            return new ArtPieceResponseDto() { ErrorMessage = productResponse.Message} ;
        }
        public async  Task CheckHighestBid(Guid productId, HighestBid highestBid)
        {
            var client = _httpClient.CreateClient("Product");
            var jsonContent = JsonConvert.SerializeObject(highestBid);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(productId.ToString(), stringContent);
            var content = await response.Content.ReadAsStringAsync();
            ResponseDTO productResponse = JsonConvert.DeserializeObject<ResponseDTO>(content);
        }



    }
}
