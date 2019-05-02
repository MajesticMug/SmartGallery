using System.IO;
using System.Threading.Tasks;
using SmartGallery.Domain.Images;

namespace SmartGallery.Data.Repositories.Images
{
    public class FileSystemImageFileRepository : IImageFileRepository
    {
        public async Task SaveImageBytesAsync(ImageData imageData, byte[] imageBytes)
        {
            using (FileStream fileStream = new FileStream(imageData.FilePath, FileMode.Create))
            {
                await fileStream.WriteAsync(imageBytes);
            }
        }

        public async Task LoadImageBytesAsync(params ImageData[] imageDataList)
        {
            foreach (ImageData imageData in imageDataList)
            {
                using (FileStream fileStream = new FileStream(imageData.FilePath, FileMode.Create))
                {
                    await fileStream.ReadAsync(imageData.ImageBytes);
                }
            }
        }
    }
}