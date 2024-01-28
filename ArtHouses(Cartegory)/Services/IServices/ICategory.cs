﻿using ArtHouses_Cartegory_.Models;
using ArtHouses_Cartegory_.Models.DTOs;

namespace ArtHouses_Cartegory_.Services.IServices
{
    public interface ICategory
    {
        public Task<string> AddCategory(CategoryDTO categoryDTO);
        public Task<Category> GetCategory(Guid id);
        public Task<List<Category>> GetAllCategories();
        public Task<string> UpdateCategory();
        public Task<string> DeleteCategory(Category category);
        
    }
}
