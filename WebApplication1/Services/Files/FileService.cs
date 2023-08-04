using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System;
using System.Linq;
using System.IO.Pipelines;
using WebApplication1.Data;
using System.Data.Entity;
using System.Text;
using java.io;
//using Microsoft.EntityFrameworkCore;

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

        public async Task<Models.File?> AddFile(Models.File file)
        {
            if (file == null || file.FileData.Length == 0)
            {
                return null;
            }                       
            else
            {
                //Saves the modelfile to a file
                System.IO.File.WriteAllBytes(file.FileName, file.FileData);

                System.Console.WriteLine("this is the filename", file.FileName);
                System.Console.WriteLine("the file content",Encoding.UTF8.GetString(file.FileData));

                await _db.Files.AddAsync(file);
                System.Console.WriteLine("File uploaded successfully.");
                     
                return file;
            }
        }


        //UPDATE filedata
        public async Task<Models.File?> UpdateFile(Models.File file, string fileName)
        {
            //
            var ToUpdateFile = await _db.Files.FindAsync(fileName);
            if (ToUpdateFile == null )
            {
                System.Console.WriteLine("File not found.");
                return null;
            }
            else
            {
                ToUpdateFile.FileName=file.FileName;
                ToUpdateFile.FileData=file.FileData;    

                return  ToUpdateFile;
            }
        }

        //delete the file
        //TODO delete content from file
        public async Task<Models.File?> DeleteFile( string fileName)
        {
            var ToDeleteFile = await _db.Files.FindAsync(fileName);

            if (ToDeleteFile == null)
            {
                System.Console.WriteLine("File not found.");
                return null;
            }
            else {
                _db.Files.Remove(ToDeleteFile);
                System.Console.WriteLine("File deleted successfully.");
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

