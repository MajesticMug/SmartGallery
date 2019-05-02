using System.Collections.Generic;
using System.Threading.Tasks;
using SmartGallery.Domain.Images;

namespace SmartGallery.Data.Repositories.Images
{
    public interface IImageDataRepository
    {
        // Get
        Task<IList<ImageData>> GetAllImagesAsync(int pageNumber, int pageSize);
        Task<IList<ImageData>> GetImagesByCategoryAsync(string categoryName, int pageNumber, int pageSize);
        Task<ImageData> GetImageDataAsync(int imageDataId);

        // Save
        Task SaveImageDataAsync(ImageData imageData);
    }
}