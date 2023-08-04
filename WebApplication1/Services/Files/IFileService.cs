using Microsoft.AspNetCore.Http;
using WebApplication1.Models;
using File = WebApplication1.Models.File;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services.Files
{
    public interface IFileService
    {
        Task<IEnumerable<FileDTO?>> GetAllFiles();

        Task<FileDTO?> GetFileByName(string fileName);

        Task<FileDTO> AddFile(File file);

        Task<FileDTO?> UpdateFile(File file,string fileName);

        Task<FileDTO?> DeleteFile(string fileName);

        Task Save();
        //public File ImageTestCreation();

        //byte[] SerializeDataFile(File file);

        //Task WriteContentIntoFile(File file);
    }
}
