using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using WebApplication1.Services.Files;

namespace WebApplication1.Controllers
{
    [Route("api/filecontroller")]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        // GET: api/file
        [HttpGet]
        public async Task<IActionResult> GetAllFiles()
        {
            var files = await _fileService.GetAllFiles();
            return Ok(files);
        }

        // GET: api/file/{fileName}
        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetFileByName(string fileName)
        {
            var file = await _fileService.GetFileByName(fileName);
            if (file == null)
                return NotFound();

            return Ok(new { file.FileName, file.FileData.Length });
        }

        // POST: api/file
        [HttpPost]
        public async Task<IActionResult> AddFile(Models.File file)
        {
            var result = await _fileService.AddFile(file);
            return Ok(result);
        }

        // PUT: api/file/{fileName}
        [HttpPut("{fileName}")]
        public async Task<IActionResult> UpdateFile(string fileName)
        {
            var result = await _fileService.UpdateFile(fileName);
            return Ok(result);
        }

        // DELETE: api/file/{fileName}
        [HttpDelete("{fileName}")]
        public async Task<IActionResult> DeleteFile(string fileName)
        {
            var result = await _fileService.DeleteFile(fileName);
            return NoContent();
        }
    }
}
