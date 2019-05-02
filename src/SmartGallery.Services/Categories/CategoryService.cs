using System.Collections.Generic;
using System.Threading.Tasks;
using SmartGallery.Data.Repositories.Categories;
using SmartGallery.Domain.Images;

namespace SmartGallery.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public async Task<IList<ImageCategory>> GetAllCategories()
        {
            return await this._categoryRepository.GetAllCategoriesAsync();
        }

        public async Task SaveCategory(string name, string description)
        {
            await this._categoryRepository.SaveCategory(new ImageCategory
            {
                Name = name,
                Description = description
            });
        }
    }
}