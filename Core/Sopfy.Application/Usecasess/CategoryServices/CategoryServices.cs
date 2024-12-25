using Sopfy.Application.Dtos.CategroyDtos;
using Sopfy.Application.Interfaces;
using Sopfy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sopfy.Application.Usecasess.CategoryServices
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IRepostory<Category> _repostory;

        public CategoryServices(IRepostory<Category> repostory)
        {
            _repostory = repostory;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto model)
        {
            await _repostory.CreateAsync(new Category 
            {
                CategoryName = model.CategoryName,
            });
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _repostory.GetByIdAsync(id);
            await _repostory.DeleteAsync(category);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategortAsync()
        {
            var categories = await _repostory.GetAllAsync();
            return categories.Select(x => new ResultCategoryDto
                {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
                }).ToList();
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(int id)
        {
            var category = await _repostory.GetByIdAsync(id);
            var newcategory = new GetByIdCategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
            };
            return newcategory;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto model)
        {
            var category = await _repostory.GetByIdAsync(model.CategoryId);
            category.CategoryName = model.CategoryName;
            await _repostory.UpdateAsync(category);
        }
    }
}
