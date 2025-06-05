using GamingCorner.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamingCorner.API.Controllers
{
    public class UploadController : ControllerBase
    {
        private readonly CloudinaryService _cloudinaryService;

        public UploadController(CloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
                return BadRequest("Imagen no válida.");

            var imageUrl = await _cloudinaryService.UploadImageRawAsync(image);
            return Ok(new { Url = imageUrl });
        }
    }

}
