using AuthMS.Models.DTOs;
using AuthMS.Services.Iservices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthServiceController : ControllerBase
    {
        private readonly IAuth _authService;
        private readonly ResponseDTO _response;

        public AuthServiceController(IAuth auth)
        {
            _authService = auth;
            _response = new ResponseDTO();

        }


        [HttpPost]
        public async Task<ActionResult<string>> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var result = await _authService.RegisterUser(registerUserDTO);
            if (string.IsNullOrWhiteSpace(result))
            {
                _response.Message = "User Was Registered Successfully";
                return Created("", _response);
            }
            else
            {
                _response.Message = result;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
        }
    }
}
