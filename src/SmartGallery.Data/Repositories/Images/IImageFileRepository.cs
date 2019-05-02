using System.Threading.Tasks;
using SmartGallery.Domain.Images;

namespace SmartGallery.Data.Repositories.Images
{
    public interface IImageFileRepository
    {
        Task SaveImageBytesAsync(ImageData imageData, byte[] imageBytes);
        Task LoadImageBytesAsync(params ImageData[] imageDataList);
    }
}