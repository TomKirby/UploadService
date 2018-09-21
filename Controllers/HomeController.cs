using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UploadService.Models;

namespace UploadService.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles(List<IFormFile> file)
        {
            if (file == null || file.Count == 0)
                return BadRequest("Server Error: No File Provided.");

            foreach (var currentFile in file)
            {
                var path = "c:/fileupload/test.jpg";//Path.Combine(Directory.GetCurrentDirectory(), "wwwroot",file.GetFilename());

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await currentFile.CopyToAsync(stream);
                }
            }

            return Ok("Green Snot");
        }
    }
}