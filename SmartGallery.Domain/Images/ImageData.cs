using System.Collections.Generic;
using System.Linq;

namespace SmartGallery.Domain.Images
{
    public class ImageData
    {
        private readonly List<Tag> _tags = new List<Tag>();

        public int Id { get; set; }
        public byte[] ImageBytes { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public ImageCategory Category { get; set; }

        public IReadOnlyCollection<Tag> Tags => _tags.AsReadOnly();

        public void AddTag(string name)
        {
            _tags.Add(new Tag
            {
                Name = name
            });
        }
    }
}