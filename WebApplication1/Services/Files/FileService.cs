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
using WebApplication1.Data;
using System.Data.Entity;
using com.sun.xml.@internal.bind.v2.model.core;
using java.nio.file;

namespace WebApplication1.Services.Files
{
    public class FileService : IFileService
    {
        
        private readonly ApplicationDbContext _db;

        public FileService(ApplicationDbContext db)
        {
            this._db = db;
        }
        public async Task<IEnumerable<Models.File?>> GetAllFiles()
        {
            var files= await _db.Files.ToListAsync();
            return files;
        }

        public async Task<Models.File?> GetFileByName(string fileName)
        {
            var file = await _db.Files.FindAsync(fileName);
            if (file == null)
            {
                return null;
            }
            else
            {
                return file;
            }            
        }

        public async Task<Models.File> AddFile(Models.File file)
        {
            await _db.Files.AddAsync(file);
            Console.WriteLine("File uploaded successfully.");
            return file;
        }

        public async Task<Models.File?> UpdateFile(string fileName)
        {
            var ToUpdateFile = await _db.Files.FindAsync(fileName);
            if (ToUpdateFile == null)
            { 
                Console.WriteLine("File not found.");
                return null;
            }
            else
            {
                byte[] bytearray = ToUpdateFile.FileData;
                using (var filestream = new MemoryStream(bytearray))
                {
                    using (var ms = new MemoryStream())
                    {
                        await Task.Run(() => ms.CopyToAsync(filestream));
                        ToUpdateFile.FileData = filestream.ToArray();
                    }
                }
            }

            Console.WriteLine( "File updated successfully.");
            return ToUpdateFile;
        }

        public async Task<Models.File?> DeleteFile(string fileName)
        {
            var ToDeleteFile = await _db.Files.FindAsync(fileName);

            if (ToDeleteFile == null)
            {
                Console.WriteLine("File not found.");
                return null;
            }
            else {
                _db.Files.Remove(ToDeleteFile);
                Console.WriteLine("File deleted successfully.");
                return ToDeleteFile;
            }
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }

}

