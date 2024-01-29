using ArtHouses_Cartegory_.Models;
using ArtHouses_Cartegory_.Models.DTOs;
using ArtHouses_Cartegory_.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtHouses_Cartegory_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICategory _service;
        private readonly ResponseDTO _response;
        public CategoryController(IMapper mapper, ICategory service)
        {
            _mapper = mapper;
            _service = service;
            _response = new ResponseDTO();
        }
        [HttpPost]
        public async Task<ActionResult<ResponseDTO>> AddNewCategory(CategoryDTO categoryDTO)
        {

            var result = await _service.AddCategory(categoryDTO);
           

            
            return Created("", result);

        }
        [HttpGet]
        public async Task<ActionResult<ResponseDTO>> GetAllCategories()
        {
            var categories = await _service.GetAllCategories();
            if (categories==null)
            {
                _response.Message = "No Categories added yet";
                _response.Result = categories;
                return NotFound(_response);
                
            }
            _response.Message = "These are the available categories at the moment";
            _response.Result = categories;
            return Ok(_response);
        }
        [HttpGet("CategoryId/{Id}")]
        public async Task<ActionResult<ResponseDTO>> GetCategoryById(Guid Id)
        {
            try
            {
                var result = await _service.GetCategory(Id);
                if (result == null)
                {
                    _response.Message = "No Category was found associated with that id!";
                    _response.Result = result;
                    return NotFound(_response);
                }
                _response.Message = "This is what we found";
                _response.Result = result;
                return Ok(_response);

            }
            catch (Exception ex)
            {

                _response.Message= ex.Message;
                return BadRequest(_response);
            }
            

        }

    }
}
