using System.Collections.Generic;
using System.Threading.Tasks;
using SmartGallery.Domain.Images;

namespace SmartGallery.Data.Repositories.Categories
{
    public interface ICategoryRepository
    {
        Task<IList<ImageCategory>> GetAllCategoriesAsync();

        Task SaveCategory(ImageCategory category);
    }
}