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
        public async Task<IEnumerable<FileDTO?>> GetAllFiles()
        {
            var files = await _db.Files.ToListAsync();
            var filesDto=files.Select(file=>_mapper.Map<FileDTO>(file));
           
            return filesDto;            
        }

        public async Task<Models.FileDTO?> GetFileByName(string fileName)
        {
            var file = await _db.Files.FirstOrDefaultAsync(f => f.FileName == fileName);
            if (file == null)
            {
                return null;
            }
            else
            {
                var fileDTO = _mapper.Map<FileDTO>(file);
                return fileDTO;
            }
        }

        public async Task<Models.FileDTO?> AddFile(Models.File file)
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

                var fileDTO = _mapper.Map<FileDTO>(file);
                return fileDTO;
            }
        }


        //UPDATE filedata
        public async Task<Models.FileDTO?> UpdateFile(Models.File file, string fileName)
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
                ToUpdateFile.FileData=file.FileData;

                var ToUpdateFileDTO = _mapper.Map<FileDTO>(ToUpdateFile);
                return  ToUpdateFileDTO;
            }
        }

        //delete the file
        public async Task<Models.FileDTO?> DeleteFile( string fileName)
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
                var ToDeleteFileDTO = _mapper.Map<FileDTO>(ToDeleteFile);
                return ToDeleteFileDTO;
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

