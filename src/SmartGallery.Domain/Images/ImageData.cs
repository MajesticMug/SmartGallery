using System.Collections.Generic;

namespace SmartGallery.Domain.Images
{
    public class ImageData
    {
        private readonly List<Tag> _tags = new List<Tag>();

        public int ImageDataId { get; set; }

        public string FileName { get; set; }

        public string FilePath => this.Category != null ? $"{this.Category.Name}\\{this.FileName}" : this.FileName;

        public byte[] ImageBytes { get; set; }

        public string Description { get; set; }
        public ImageCategory Category { get; set; }

        public IReadOnlyCollection<Tag> Tags => this._tags.AsReadOnly();

        public void AddTag(string name)
        {
            this._tags.Add(new Tag
            {
                Name = name
            });
        }
    }
}