using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using WebApplication1.Services.Files;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    [Route("Fileapi/[Controller]")]
    [ApiController]
    //[Area("FileController")]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        // GET: api/file
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileDTO>>> GetAllFiles()
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

            return Ok(new{ file.FileName,file.FileContent.Length});
        }

        // POST: api/file
        [HttpPost]
        public async Task<IActionResult> AddFile(Models.File file)
        {
            var NewFile = await _fileService.AddFile(file);
            if (NewFile == null)
            {
                return BadRequest();
            }
            else
            {
                
                await _fileService.Save();
                return Ok(NewFile);
            }
        }

        // PUT: api/file/{fileName}
        [HttpPut("{fileName}")]
        public async Task<IActionResult> UpdateFile(Models.File file,string fileName)
        {
            var ToUpdateFile = await _fileService.UpdateFile(file,fileName);
            if (ToUpdateFile == null)
            {
                return NotFound();
            }
            else
            {
                await _fileService.Save();
                return Ok(ToUpdateFile);
            }
        }

        // DELETE: api/file/{fileName}
        [HttpDelete("{fileName}")]
        public async Task<IActionResult> DeleteFile(string fileName)
        {
            var ToDeleteFile = await _fileService.DeleteFile(fileName);
            if (ToDeleteFile == null)
            {
                return NotFound();
            }
            else
            {
                await _fileService.Save();
                return NoContent();
            }
        }
    }
}
