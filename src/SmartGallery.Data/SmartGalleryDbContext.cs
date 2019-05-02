using Microsoft.EntityFrameworkCore;
using SmartGallery.Domain.Images;

namespace SmartGallery.Data
{
    public class SmartGalleryDbContext : DbContext
    {
        public DbSet<ImageData> Images { get; set; }
        public DbSet<ImageCategory> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        
        public SmartGalleryDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}