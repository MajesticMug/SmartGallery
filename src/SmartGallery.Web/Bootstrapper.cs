using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartGallery.Data;
using SmartGallery.Data.Repositories.Categories;
using SmartGallery.Data.Repositories.Images;
using SmartGallery.Data.Repositories.Tags;
using SmartGallery.Services.Categories;
using SmartGallery.Services.Images;

namespace SmartGallery.Web
{
    public class Bootstrapper
    {
        public static void BootstrapServices(IServiceCollection services)
        {
            services.AddDbContext<SmartGalleryDbContext>(builder =>
                {
                    builder.UseInMemoryDatabase("InMemorySmartGallery");
                });

            services.AddScoped<IImageDataRepository, EfImageDataRepository>();
            services.AddScoped<IImageFileRepository, FileSystemImageFileRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}