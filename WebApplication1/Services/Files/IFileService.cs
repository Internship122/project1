﻿using WebApplication1.Models;
using File = WebApplication1.Models.File;

namespace WebApplication1.Services.Files
{
    public interface IFileService
    {
        Task<IEnumerable<File?>> GetAllFiles();

        Task<File?> GetFileByName(string fileName);

        Task<File> AddFile(File file);

        Task<File?> UpdateFile(string fileName);

        Task<File>? DeleteFile(string fileName);

        Task Save();
    }
}
