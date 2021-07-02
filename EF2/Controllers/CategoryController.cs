using System.Collections.Generic;
using EF2.Models;
using EF2.Models.DTO;
using EF2.Services;
using Microsoft.AspNetCore.Mvc;

namespace EF2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public List<Category> List()
        {
            return _categoryService.GetCategories();
        }
        [HttpGet("{id}")]
        public Category GetById(int id)
        {
            return _categoryService.GetCategoryById(id);
        }
        [HttpPost]
        public List<Category> Create(CategoryDTO category)
        {
            _categoryService.CreateCategory(category);
            return _categoryService.GetCategories();
        }
        [HttpPut("{id}")]
        public List<Category> Update(CategoryDTO category,int id)
        {
            _categoryService.UpdateCategory(category, id);
            return _categoryService.GetCategories();
        }
        [HttpDelete("{id}")]
        public List<Category> Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return _categoryService.GetCategories();
        }
    }
}
