
using BiddingMS.Models.DTOs;
using BiddingMS.Services.IService;
using Newtonsoft.Json;

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
        public async Task<ResponseDTO> GetAllProducts(Guid productId)
        {
            var client = _httpClient.CreateClient("Product");
            var response = await client.GetAsync(productId.ToString());
            var content = await response.Content.ReadAsStringAsync();
            ResponseDTO productResponse = JsonConvert.DeserializeObject<ResponseDTO>(content);
            if (productResponse==null)
            {
                _responseDTO.Message = "Not found";
                _responseDTO.Result = productResponse;
                return _responseDTO;
                
            }
            return productResponse;
        }

        public async Task<ResponseDTO> GetProductById()
        {
            //var client = _httpClient.CreateClient("Product");
            //var response = await client.GetAsync(productId.ToString());
            //var content = await response.Content.ReadAsStringAsync();
            //ArtPieceDisplayDTO productResponse = JsonConvert.DeserializeObject<ArtPieceDisplayDTO>(content);
            //return productResponse;
        }
    }
}
