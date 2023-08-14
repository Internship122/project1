using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System;
using System.Linq;
using System.IO.Pipelines;
using WebApplication1.Data;
using System.Text;
using java.io;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AutoMapper;

namespace WebApplication1.Services.Files
{
    public class FileService : IFileService
    {

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public FileService(ApplicationDbContext db, IMapper mapper)
        {
            this._db = db;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Models.File?>> GetAllFiles()
        {
            var files = await _db.Files.ToArrayAsync();
           
            return files;            
        }

        public async Task<Models.File?> GetFileByName(string fileName)
        {
            var file = await _db.Files.FirstOrDefaultAsync(f => f.FileName == fileName);
            if (file == null)
            {
                return null;
            }
            else
            {
                return file;
            }
        }

        public async Task<Models.File?> AddFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }                       
            else
            {
                var filePath = file.FileName;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                };


                var NewFile = new Models.File()
                {
                    FileName = file.FileName,
                    FileData = GetFileBytes(file)
                };
                await _db.Files.AddAsync(NewFile);
                System.Console.WriteLine("File uploaded successfully.");

                return NewFile;
            }
        }


        //UPDATE filedata
        public async Task<Models.File?> UpdateFile(IFormFile file, string fileName)
        {
            //
            var ToUpdateFile = await _db.Files.FirstOrDefaultAsync(f => f.FileName == fileName);
            if (ToUpdateFile == null )
            {
                System.Console.WriteLine("File not found.");
                return null;
            }
            else
            {
                ToUpdateFile.FileName=file.FileName;
                ToUpdateFile.FileData=GetFileBytes(file);

                return  ToUpdateFile;
            }
        }

        //delete the file
        public async Task<Models.File?> DeleteFile( string fileName)
        {
            var ToDeleteFile = await _db.Files.FirstOrDefaultAsync(f => f.FileName == fileName);

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

        public Byte[] GetFileBytes(IFormFile file)
        {
            using (var memoryStream = new System.IO.MemoryStream())
            {
                file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }

}

