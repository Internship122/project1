﻿using Microsoft.AspNetCore.Http;
using WebApplication1.Models;
using File = WebApplication1.Models.File;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services.Files
{
    public interface IFileService
    {
        Task<IEnumerable<File?>> GetAllFiles();

        Task<File?> GetFileByName(string fileName);

        Task<File> AddFile(File file);

        Task<File?> UpdateFile(File file,string fileName);

        Task<File?> DeleteFile(string fileName);

        Task Save();
        //public File ImageTestCreation();

        //byte[] SerializeDataFile(File file);

        //Task WriteContentIntoFile(File file);
    }
}
