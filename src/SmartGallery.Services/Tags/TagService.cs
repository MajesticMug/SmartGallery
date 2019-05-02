using System.Collections.Generic;
using System.Threading.Tasks;
using SmartGallery.Data.Repositories.Tags;
using SmartGallery.Domain.Images;

namespace SmartGallery.Services.Tags
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            this._tagRepository = tagRepository;
        }

        public async Task<IList<Tag>> GetAllTags()
        {
            return await this._tagRepository.GetAllTagsAsync();
        }
    }
}