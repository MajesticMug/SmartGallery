namespace SmartGallery.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly SmartGalleryDbContext DbContext;

        protected BaseRepository(SmartGalleryDbContext dbContext)
        {
            this.DbContext = dbContext;
        }
    }
}