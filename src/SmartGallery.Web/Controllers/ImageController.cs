using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartGallery.Services.Images;

namespace SmartGallery.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(string category, string description)
        {
            var file = this.Request.Form.Files[0];
            byte[] fileBytes = null;
            
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
                // act on the Base64 data
            }

            return new OkObjectResult(await this._imageService.SaveImageAsync(file.FileName, fileBytes, category, description));
        }
    }
}