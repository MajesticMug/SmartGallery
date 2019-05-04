using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartGallery.Domain.Images;

namespace SmartGallery.Data.Repositories.Categories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(SmartGalleryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<ImageCategory>> GetAllCategoriesAsync()
        {
            return await this.DbContext.Categories.AsNoTracking().ToListAsync();
        }

        public async Task SaveCategory(ImageCategory category)
        {
            await this.DbContext.Categories.AddAsync(category);

            await this.DbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(string categoryName)
        {
            return await this.DbContext.Categories.AnyAsync(category => category.Name == categoryName);
        }
    }
}