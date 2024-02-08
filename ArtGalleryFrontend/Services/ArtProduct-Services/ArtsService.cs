using ArtGalleryFrontend.Models;
using ArtGalleryFrontend.Models.ArtProducts;
using Newtonsoft.Json;
using System.Text;

namespace ArtGalleryFrontend.Services.ArtProduct_Services
{
    public class ArtsService:IArt
    {
        private readonly HttpClient _httpClient;
        private readonly string BASEURL = "https://localhost:7181";
        public ArtsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDTO> AddArt(AddArtPieceDTO art)
        {
            var request = JsonConvert.SerializeObject(art);
            var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{BASEURL}/api/Product", bodyContent);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<ResponseDTO>(content);
            if (results.IsSuccess)
            {

                return results;

            }

            return new ResponseDTO();
        }

        public async Task<ResponseDTO> deleteArt(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{BASEURL}/api/Product?ProductId={id}");
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<ResponseDTO>(content);
            if (results.IsSuccess)
            {

                return results;

            }

            return new ResponseDTO();
        }

        public async Task<ArtDto> GetArtByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"{BASEURL}/api/Product/SingleProduct/{id}");
            var content = await response.Content.ReadAsStringAsync();

            var results = JsonConvert.DeserializeObject<ResponseDTO>(content);

            if (results.IsSuccess)
            {
                //change this to a list of products
                return JsonConvert.DeserializeObject<ArtDto>(results.Result.ToString());

            }
            return new ArtDto();
        }

        public async Task<List<ArtDisplay>> GetArtsAsync()
        {
            var response = await _httpClient.GetAsync($"{BASEURL}/api/Product");
            var content = await response.Content.ReadAsStringAsync();


            var results = JsonConvert.DeserializeObject<ResponseDTO>(content);

            if (results.IsSuccess)
            {

                return JsonConvert.DeserializeObject<List<ArtDisplay>>(results.Result.ToString());

            }
            return new List<ArtDisplay>();
        }



        public async Task<ResponseDTO> updateArt(Guid id, ArtRequestDto artRequestDto)
        {
            var request = JsonConvert.SerializeObject(artRequestDto);
            var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{BASEURL}/api/Product/{id}", bodyContent);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<ResponseDTO>(content);
            if (results.IsSuccess)
            {

                return results;

            }

            return new ResponseDTO();
        }
    }
}

