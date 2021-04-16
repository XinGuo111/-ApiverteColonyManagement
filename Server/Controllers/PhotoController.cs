using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("[controller]")]
    public class PhotoController : Controller
    {

        public static IWebHostEnvironment _environment;

        public PhotoController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost, Route("UploadColonyPhoto")]
        public async Task<IActionResult> UploadColonyPhoto(String ColonyId, IFormFile file)
        {
            Directory.CreateDirectory(Path.Combine(_environment.ContentRootPath, "Filesystem/Colonies/"));
            string path = Path.Combine(_environment.ContentRootPath, "Filesystem/Colonies/" + ColonyId + Path.GetExtension(file.FileName));
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok();
        }

        [HttpGet, Route("GetColonyPhoto")]
        public IActionResult GetColonyPhoto(string ColonyId)
        {
            var folderPath = Path.Combine(_environment.ContentRootPath, "Filesystem/Colonies/");
            var fileName = Directory.GetFiles(folderPath).Select(Path.GetFileName).FirstOrDefault(fn => fn.StartsWith(ColonyId));
            if (fileName == null) return NotFound();
            Byte[] b = System.IO.File.ReadAllBytes(Path.Combine(folderPath, fileName));
            return File(b, "image/png");
        }

        [HttpPost, Route("UploadSpecialInpectionPhoto")]
        public async Task<IActionResult> UploadSpecialInpectionPhoto(String SpecialInspectionId, IFormFile file)
        {
            Directory.CreateDirectory(Path.Combine(_environment.ContentRootPath, "Filesystem/SpecialInspections/"));
            string path = Path.Combine(_environment.ContentRootPath, "Filesystem/SpecialInspections/" + SpecialInspectionId + Path.GetExtension(file.FileName));
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok();
        }

        [HttpGet, Route("GetSpecialInspectionPhoto")]
        public IActionResult GetSpecialInspectionPhoto(string ColonyId)
        {
            var folderPath = Path.Combine(_environment.ContentRootPath, "Filesystem/SpecialInspections/");
            var fileName = Directory.GetFiles(folderPath).Select(Path.GetFileName).FirstOrDefault(fn => fn.StartsWith(ColonyId));
            if (fileName == null) return NotFound();
            Byte[] b = System.IO.File.ReadAllBytes(Path.Combine(folderPath, fileName));
            return File(b, "image/png");
        }

        [HttpPost, Route("UploadTypicalInspectionPhoto")]
        public async Task<IActionResult> UploadTypicalInspectionPhoto(String TypicalInspectionId, IFormFile file)
        {
            Directory.CreateDirectory(Path.Combine(_environment.ContentRootPath, "Filesystem/TypicalInspections/"));
            string path = Path.Combine(_environment.ContentRootPath, "Filesystem/TypicalInspections/" + TypicalInspectionId + Path.GetExtension(file.FileName));
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok();
        }

        [HttpGet, Route("GetTypicalInspectionPhoto")]
        public IActionResult GetTypicalInspectionPhoto(string ColonyId)
        {
            var folderPath = Path.Combine(_environment.ContentRootPath, "Filesystem/TypicalInspections/");
            var fileName = Directory.GetFiles(folderPath).Select(Path.GetFileName).FirstOrDefault(fn => fn.StartsWith(ColonyId));
            if (fileName == null) return NotFound();
            Byte[] b = System.IO.File.ReadAllBytes(Path.Combine(folderPath, fileName));
            return File(b, "image/png");
        }


    }
}
