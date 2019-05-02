using System.Collections.Generic;
using System.Threading.Tasks;
using SmartGallery.Domain.Images;

namespace SmartGallery.Data.Repositories.Tags
{
    public interface ITagRepository
    {
        Task<IList<Tag>> GetAllTagsAsync();

        Task SaveTagAsync(Tag tag);
    }
}