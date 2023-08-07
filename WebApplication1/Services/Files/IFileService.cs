using Microsoft.AspNetCore.Http;
using WebApplication1.Models;
using File = WebApplication1.Models.File;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services.Files
{
    public interface IFileService
    {
        Task<IEnumerable<File?>> GetAllFiles();

        Task<File?> GetFileByName(string fileName);

        Task<File> AddFile(IFormFile file);

        Task<File?> UpdateFile( IFormFile file,string fileName);

        Task<File?> DeleteFile(string fileName);

        Task Save();

        byte[] GetFileBytes(IFormFile file);
    }
}
