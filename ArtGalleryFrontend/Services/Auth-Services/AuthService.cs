using ArtGalleryFrontend.Models;
using ArtGalleryFrontend.Models.Auth_Models;
using ArtGalleryFrontend.Pages;
using Newtonsoft.Json;
using System.Text;

namespace ArtGalleryFrontend.Services.AuthServices
{
    public class AuthService : IAuth
    {
        private readonly HttpClient _httpClient;
        private readonly string BASEURL = "https://localhost:7271";
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDto)
        {
            //Serialize Request Data: --It serializes the loginRequestDto object into a JSON string using JsonConvert.SerializeObject.
            string stringfiedRequest = JsonConvert.SerializeObject(loginRequestDto);

            //Prepare Request Body: ---It creates a StringContent object bodyContent with the serialized JSON request data and sets the content type to "application/json".
            StringContent bodyContent = new StringContent(stringfiedRequest, Encoding.UTF8, "application/json");

            //Send POST Request: ---- It sends a POST request to the API endpoint ${BASEURL}/api/User with the prepared request body.
            HttpResponseMessage response = await _httpClient.PostAsync($"{BASEURL}/api/User/login", bodyContent);



            /*Handle Response:

            Upon receiving the response, it reads the content as a string.
            It deserializes the response content into a ResponseDTO object named finalResult using JsonConvert.DeserializeObject.
            It checks if the IsSuccess property of the finalResult object is true.
            
             */
            string content = await response.Content.ReadAsStringAsync();
            ResponseDTO? finalResult = JsonConvert.DeserializeObject<ResponseDTO>(content);

            if (finalResult.IsSuccess)
            {
                /*Return Result:

                 If the login operation was successful (finalResult.IsSuccess is true), 
                it deserializes the Result property of the finalResult object into 
                a LoginResponseDTO object and returns it.
                */

                return JsonConvert.DeserializeObject<LoginResponseDTO>(finalResult.Result.ToString());
            }
            //Return Result:
            // If the login operation was successful(finalResult.IsSuccess is true), it deserializes the Result property of the finalResult object into a LoginResponseDTO object and returns it.

            return new LoginResponseDTO();
        }


        public async Task<ResponseDTO> Register(RegisterRequestDTO registerRequestDto)
        {
            string stringfiedRequest = JsonConvert.SerializeObject(registerRequestDto);

            StringContent bodyContent = new StringContent(stringfiedRequest, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync($"{BASEURL}/api/User", bodyContent);
            string content = await response.Content.ReadAsStringAsync();
            ResponseDTO finalResult = JsonConvert.DeserializeObject<ResponseDTO>(content);

            return finalResult;


        }

    }
}
