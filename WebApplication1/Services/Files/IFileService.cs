using WebApplication1.Models;
using File = WebApplication1.Models.File;

namespace WebApplication1.Services.Files
{
    public interface IFileService
    {
        Task<IEnumerable<File>> GetAllFiles();
        Task<File> GetFileByName(string fileName);
        Task AddFile(File file);
        Task UpdateFile(string fileName);
        Task DeleteFile(string fileName);
    }
}
