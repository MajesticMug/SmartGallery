using System.IO;
using System.Threading.Tasks;
using SmartGallery.Domain.Images;

namespace SmartGallery.Data.Repositories.Images
{
    public class FileSystemImageFileRepository : IImageFileRepository
    {
        private readonly string _targetPath = "C:\\SmartGallery\\Images\\";

        public async Task SaveImageBytesAsync(ImageData imageData, byte[] imageBytes)
        {
            string targetDirectory = Path.Combine(this._targetPath, imageData.Category.Name);

            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            string filePath = Path.Combine(targetDirectory, imageData.FileNameToSave);

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await stream.WriteAsync(imageBytes, 0, imageBytes.Length);
            }
        }

        public async Task LoadImageBytesAsync(params ImageData[] imageDataList)
        {
            foreach (ImageData imageData in imageDataList)
            {
                using (FileStream fileStream = new FileStream(imageData.FileNameToSave, FileMode.Create))
                {
                    await fileStream.ReadAsync(imageData.ImageBytes);
                }
            }
        }
    }
}