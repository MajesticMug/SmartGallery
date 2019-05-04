using System.Collections.Generic;

namespace SmartGallery.Domain.Images
{
    public class ImageCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IList<ImageData> Images { get; set; }
    }
}