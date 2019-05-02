using System.Collections.Generic;
using System.Threading.Tasks;
using SmartGallery.Domain.Images;

namespace SmartGallery.Services.Categories
{
    public interface ICategoryService
    {
        Task<IList<ImageCategory>> GetAllCategories();

        Task SaveCategory(string name, string description);
    }
}