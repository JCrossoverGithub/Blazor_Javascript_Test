using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;


namespace Blazor_Javascript_Test.Server.Controllers
{
    public class SaveAudio : Controller
    {
        Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hostingEnvironment;

        public SaveAudio(Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

        }

        [Route("api/[controller]/Save")]
        [HttpPost]
        public async Task<IActionResult> Save(IFormFile file)
        {
            if (file.ContentType != "audio/wav")
            {
                return BadRequest("Wrong file type");
            }
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");

            var filePath = Path.Combine(uploads, file.FileName + ".wav");
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return Ok("File uploaded successfully");
        }
    }
}