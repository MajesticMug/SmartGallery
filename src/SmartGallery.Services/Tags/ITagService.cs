using System.Collections.Generic;
using System.Threading.Tasks;
using SmartGallery.Domain.Images;

namespace SmartGallery.Services.Tags
{
    public interface ITagService
    {
        Task<IList<Tag>> GetAllTags();
    }
}