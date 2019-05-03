using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using SmartGallery.Domain.Images;

namespace SmartGallery.Data.Repositories.Images
{
    public class FileSystemImageFileRepository : IImageFileRepository
    {
        public async Task SaveImageBytesAsync(ImageData imageData, byte[] imageBytes)
        {
            string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string targetPath = Path.Combine(currentPath, imageData.FilePath);

            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }

            using (var stream = new FileStream(targetPath, FileMode.Create))
            {
                await stream.WriteAsync(imageBytes, 0, imageBytes.Length);
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