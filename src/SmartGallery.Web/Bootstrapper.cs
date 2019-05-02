using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartGallery.Data;
using SmartGallery.Data.Repositories.Categories;

namespace SmartGallery.Web
{
    public class Bootstrapper
    {
        public static void BootstrapServices(IServiceCollection services)
        {
            services.AddScoped<DbContext, SmartGalleryDbContext>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            // todo:
        }
    }
}