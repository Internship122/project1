using HotChocolate.Execution;
using WebApplication1.Services.Files;

namespace WebApplication1.GraphQl.Mutations
{
    public class FileMutation
    {
        private readonly IFileService _fileService;
        public FileMutation(IFileService fileService)
        {
            _fileService = fileService;
        }
        public async Task<Models.File> AddFile(FileInputType file)
        {
            var NewFile = await _fileService.AddFile((IFormFile)file);
            await _fileService.Save();
            return NewFile;
        }
        public async Task<Models.File> UpdateFile(FileInputType file, string fileName)
        {
            var ToUpdateFile = await _fileService.UpdateFile((IFormFile)file, fileName);
            if (ToUpdateFile == null)
            {
                throw new QueryException("File Not Found");
            }
            else
            {
                await _fileService.Save();
                return ToUpdateFile;
            }
        }
        public async Task<Models.File> DeleteFile(string fileName)
        {
            var ToDeleteFile = await _fileService.DeleteFile(fileName);
            if (ToDeleteFile == null)
            {
                throw new QueryException("File Not Found");
            }
            else
            {
                await _fileService.Save();
                return ToDeleteFile;
            }
        }
    }
}
