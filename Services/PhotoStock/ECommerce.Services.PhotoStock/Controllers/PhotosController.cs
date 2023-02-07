using ECommerce.Services.PhotoStock.DTOs;
using ECommerce.Shared.ControllerBases;
using ECommerce.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace ECommerce.Services.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile formFile)
        {
            if (formFile != null && formFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", formFile.FileName);
                var stream = new FileStream(path, FileMode.Create);
                await formFile.CopyToAsync(stream);
                var returnPath = "photos/" + formFile.FileName;
                PhotoDto photoDto = new()
                {
                    URL = returnPath
                };

                return CreateActionResultInstance(ResponseDto<PhotoDto>.Success(photoDto, 200));
            }
            return CreateActionResultInstance(ResponseDto<PhotoDto>.Fail("Bir hata oluştu!", 400));
        }
    }
}
