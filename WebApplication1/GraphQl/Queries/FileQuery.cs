using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services.Files;
using HotChocolate.Data;
using HotChocolate;

namespace WebApplication1.GraphQl.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class FileQuery
    {
        private readonly IFileService _fileService;
        public FileQuery(IFileService fileService)
        {
            _fileService = fileService;
        }
        [UseDbContext(typeof(ApplicationDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<FileType> GetFiles([Service] ApplicationDbContext context)
        {
            return context.Files.Select(f => new FileType()
            {
                Id = f.Id,
                Filename = f.FileName,
                FileData=f.FileData,
            }); ;
        }
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<FileType?> GetFileByFilename(string filename, [Service] ApplicationDbContext context)
        {
            Models.File file = await context.Files.FirstOrDefaultAsync(f => f.FileName == filename);

            if (file == null)
            {
                return null;
            }

            return new FileType()
            {
                Id = file.Id,
                Filename = file.FileName,
                FileData=file.FileData,
            };
        }
    }
}
