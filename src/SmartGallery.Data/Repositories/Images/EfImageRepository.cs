using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartGallery.Data.Utils;
using SmartGallery.Domain.Images;

namespace SmartGallery.Data.Repositories.Images
{
    public class EfImageDataRepository : BaseRepository, IImageDataRepository
    {
        public EfImageDataRepository(SmartGalleryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<ImageData>> GetAllImagesAsync(int pageNumber, int pageSize)
        {
            return await this.DbContext.Images
                .Include(img => img.Category).GetPage(pageNumber, pageSize).ToListAsync();
        }

        public async Task<IList<ImageData>> GetImagesByCategoryAsync(string categoryName, int pageNumber, int pageSize)
        {
            return await this.DbContext.Images.Where(img => img.Category != null && img.Category.Name == categoryName)
                .Include(img => img.Category)
                .GetPage(pageNumber, pageSize).ToListAsync();
        }

        public async Task<ImageData> GetImageDataAsync(int imageDataId)
        {
            return await this.DbContext.Images.Where(img => img.ImageDataId == imageDataId)
                .Include(img => img.Category).FirstOrDefaultAsync();
        }

        public async Task SaveImageDataAsync(ImageData imageData)
        {
            await this.DbContext.AddAsync(imageData);

            await this.DbContext.SaveChangesAsync();
        }
    }
}