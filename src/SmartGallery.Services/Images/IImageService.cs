using System.Collections.Generic;
using System.Threading.Tasks;
using SmartGallery.Domain.Images;

namespace SmartGallery.Services.Images
{
    public interface IImageService
    {
        // Get
        Task<IList<ImageData>> GetAllImagesAsync(int pageNumber, int pageSize);
        Task<IList<ImageData>> GetImagesByCategoryAsync(string categoryName, int pageNumber, int pageSize);
        Task<ImageData> GetImageDataAsync(int imageDataId);

        // Save
        Task<ImageData> SaveImageAsync(string fileName, byte[] imageBytes, string fileContentType, string categoryName = null,
            string description = null);
    }
}