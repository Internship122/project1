using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace WebApplication1.Services.Files
{
    public class FileService : IFileService
    {
        
        private static readonly List<Models.File> files = new List<Models.File>();

        public async Task<IEnumerable<Models.File>> GetAllFiles()
        {
            return await Task.FromResult(files);
        }

        public async Task<Models.File> GetFileByName(string fileName)
        {
            return await Task.FromResult(files.FirstOrDefault(f => f.FileName == fileName));
        }

        public async Task AddFile(Models.File file)
        {
            await files.AddAsync(file);
            Console.WriteLine( "File uploaded successfully.");
        }

        public async Task UpdateFile(string fileName)
        {
            var ToUpdateFile = files.FirstOrDefault(f => f.FileName == fileName);
            if (ToUpdateFile == null)
            { 
                Console.WriteLine("File not found.");
            }
            else
            {
                using (var ms = new MemoryStream())
                {
                    await ToUpdateFile.CopyToAsync(ms);
                    ToUpdateFile.FileData = ms.ToArray();
                }
            }

            Console.WriteLine( "File updated successfully.");
        }

        public Task DeleteFile(string fileName)
        {
            var ToDeleteFile = files.FirstOrDefault(f => f.FileName == fileName);
            if (ToDeleteFile == null)
            {
                Console.WriteLine("File not found.");
            }
            else {
                files.Remove(ToDeleteFile);
                Console.WriteLine("File deleted successfully.");
            }
        }
    }

}

