using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartGallery.Domain.Images;
using SmartGallery.Services.Categories;
using SmartGallery.Services.Images;

namespace SmartGallery.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly ICategoryService _categoryService;

        public ImageController(IImageService imageService, ICategoryService categoryService)
        {
            _imageService = imageService;
            _categoryService = categoryService;
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

            return new OkObjectResult(await this._imageService.SaveImageAsync(file.FileName, fileBytes, file.ContentType, category, description));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetImagesData(int pageNumber, int pageSize, string categoryName)
        {
            IList<ImageData> images;

            if (string.IsNullOrEmpty(categoryName))
            {
                images = await this._imageService.GetAllImagesAsync(pageNumber, pageSize);
            }
            else
            {
                images = await this._imageService.GetImagesByCategoryAsync(categoryName, pageNumber, pageSize);
            }

            return new OkObjectResult(images);
        }
        
        [HttpGet("[action]")]
        public async Task<IActionResult> GetImage(int imageDataId)
        {
            var imageData = await _imageService.GetImageDataAsync(imageDataId);

            return File(imageData.ImageBytes, imageData.ContentType);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCategories()
        {
            return new OkObjectResult(await this._categoryService.GetAllCategories());
        }
    }
}