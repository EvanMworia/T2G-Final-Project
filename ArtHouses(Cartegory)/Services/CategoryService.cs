using ArtHouses_Cartegory_.Database;
using ArtHouses_Cartegory_.Models;
using ArtHouses_Cartegory_.Models.DTOs;
using ArtHouses_Cartegory_.Services.IServices;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ArtHouses_Cartegory_.Services
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ResponseDTO _response;

        public CategoryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _response = new ResponseDTO();
            
        }
        public async Task<ResponseDTO> AddCategory(CategoryDTO categoryDTO)
        {
            try
            {

                var mappedCategory = _mapper.Map<Category>(categoryDTO);
                await _context.Categories.AddAsync(mappedCategory);
                await _context.SaveChangesAsync();
                _response.Message = "category added successfully";
                _response.Result = mappedCategory;
                return _response;
            }
            catch (Exception ex) 
            {
                _response.Message = ex.Message;
                return _response;
            }  
        }

        public async Task<string> DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return "Category has been deleted successfully";
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
            
        }

        public async Task<Category> GetCategory(Guid id)
        {
            var result=  await _context.Categories.Where(x => x.CategoryId == id).FirstOrDefaultAsync();
            var mappedResult = _mapper.Map<Category>(result);
            return mappedResult;
        }

        public async Task<string> UpdateCategory()
        {
            await _context.SaveChangesAsync();
            return "Updated Successfully";

        }

        
    }
}
