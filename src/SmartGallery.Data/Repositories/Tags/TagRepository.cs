using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartGallery.Domain.Images;

namespace SmartGallery.Data.Repositories.Tags
{
    public class TagRepository : BaseRepository, ITagRepository
    {
        public TagRepository(SmartGalleryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<Tag>> GetAllTagsAsync()
        {
            return await this.DbContext.Tags.ToListAsync();
        }

        public async Task SaveTagAsync(Tag tag)
        {
            await this.DbContext.Tags.AddAsync(tag);

            await this.DbContext.SaveChangesAsync();
        }
    }
}