using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO.Pipelines;
using NuGet.Protocol;

namespace WebApplication1.Services.Files
{
    public class FileService : IFileService
    {
        
        private readonly List<Models.File> files = new List<Models.File>();

        public FileService(List<Models.File> files)
        {
            files = new List<Models.File>();
        }
        public async Task<IEnumerable<Models.File?>> GetAllFiles()
        {
            return await Task.FromResult(files);
        }

        public async Task<Models.File?> GetFileByName(string fileName)
        {
            return await Task.FromResult(files.FirstOrDefault(f => f.FileName == fileName));
        }

        public async Task<Models.File> AddFile(Models.File file)
        {
            await Task.Run(()=> files.Add(file));
            Console.WriteLine( "File uploaded successfully.");
            return file;
        }

        public async Task<Models.File?> UpdateFile(string fileName)
        {
            var ToUpdateFile =await Task.FromResult(files.FirstOrDefault(f => f.FileName == fileName));
            if (ToUpdateFile == null)
            { 
                Console.WriteLine("File not found.");
                return null;
            }
            else
            {
                using (var ms = new MemoryStream())
                {
                    await Task.Run(()=> ms.CopyToAsync(ToUpdateFile.FileData));
                    ToUpdateFile.FileData = ms.ToArray();
                }
            }

            Console.WriteLine( "File updated successfully.");
            return ToUpdateFile;
        }

        public Task<Models.File>? DeleteFile(string fileName)
        {
            var ToDeleteFile = files.FirstOrDefault(f => f.FileName == fileName);

            if (ToDeleteFile == null)
            {
                Console.WriteLine("File not found.");
                return null;
            }
            else {
                files.Remove(ToDeleteFile);
                Console.WriteLine("File deleted successfully.");
                return ToDeleteFile;
            }
        }
    }

}

