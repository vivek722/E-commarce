using E_Commrece.Domain.FireBaseSevice;
using Microsoft.AspNetCore.Mvc;

namespace E_commarceWebApi.Controllers
{
    [ApiController]
    public class FireBaseController : Controller
    {
        private readonly IFireBaseUploadImageService _imageService;

        public FireBaseController(IFireBaseUploadImageService imageService)
        {
            _imageService = imageService;
        }
        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile File)
        {
            var file = Guid.NewGuid().ToString() + "-" + File.FileName;
            var path = Path.Combine(Path.GetTempPath(), file);
            var folder = "Uploads";
            using (var strem = new FileStream(path, FileMode.Create))
            {
                await File.CopyToAsync(strem);
            }
            var url = await _imageService.FireBaseUploadImageAsync(file, path, folder);
            return Ok(url);
        }
        [HttpDelete("DeleteImage")]
        public async Task<IActionResult> DeleteImage(string FileName)
        {
            var url = await _imageService.FireBaseDeleteImageAsync(FileName, "Uploads");
            return Ok(url);
        }
        [HttpGet("GetAllImage")]
        public async Task<IActionResult> GetAllImage(string FileName)
        {
            var url = await _imageService.FireBaseGetImageAsync(FileName, "Uploads");
            return Ok(url);
        }
    }
}
