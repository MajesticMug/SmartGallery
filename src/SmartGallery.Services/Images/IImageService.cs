using System.Collections.Generic;
using System.Threading.Tasks;
using SmartGallery.Domain.Images;

namespace SmartGallery.Services.Images
{
    public interface IImageService
    {
        // Get
        Task<IList<ImageData>> GetAllImages(int page, int pageSize);
        Task<IList<ImageData>> GetImagesByCategory(string categoryName, int page, int pageSize);
        Task<ImageData> GetImageData(int imageDataId);

        // Save
        Task SaveImage(string fileName, byte[] imageBytes, string categoryName = null, string description = null);
    }
}