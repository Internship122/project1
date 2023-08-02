using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using System.IO.Pipelines;
using WebApplication1.Data;
using System.Data.Entity;
using com.sun.org.apache.bcel.@internal.generic;
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
            var files = await _db.Files.ToListAsync();
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

        public async Task<Models.File?> AddFile([FromForm] IFormFile file)
        {
            var NewFile =new Models.File();
            if (file == null || file.Length == 0)
            {
                return null;
            }
            else
            {
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);

                    NewFile.FileName=file.FileName;
                    NewFile.FileData = ms.ToArray();

                    
                }
                await _db.Files.AddAsync(NewFile);
                Console.WriteLine("File uploaded successfully.");
                     
                return NewFile;
            }
        }


        //update filecontent
        public async Task<Models.File?> UpdateFile([FromForm]IFormFile file, string fileName)
        {
            //
            var ToUpdateFile = await _db.Files.FindAsync(fileName);
            if (ToUpdateFile == null)
            { 
                Console.WriteLine("File not found.");
                return null;
            }
            else
            {   
                using (var ms = new MemoryStream())
                {
                    await file.CopyToAsync(ms);
                    ToUpdateFile.FileData = ms.ToArray();
                }               
            }
            Console.WriteLine( "File updated successfully.");
            return ToUpdateFile;
        }

        //delete the file
        //delete content from file
        public async Task<Models.File?> DeleteFile( string fileName)
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

        
        //public async Task<Byte[]> ReadFileContent(IFormFile file)
        //{
        //    using (var memoryStream = new System.IO.MemoryStream())
        //    {
        //        await file.CopyToAsync(memoryStream);
        //        return memoryStream.ToArray();
        //    }
        //}
        
    }

}

