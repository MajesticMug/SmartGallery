using System.Linq;

namespace SmartGallery.Data.Utils
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> GetPage<T>(this IQueryable<T> enumerable, int pageNumber, int pageSize)
        {
            return enumerable.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}