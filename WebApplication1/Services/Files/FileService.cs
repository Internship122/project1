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
            //create the file, add the path and the content to the file 
            await _db.Files.AddAsync(file);
            Console.WriteLine("File uploaded successfully.");
            return file;
        }


        //update filename 
        //update filecontent
        public async Task<Models.File?> UpdateFile(string fileName)
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
        //delete the file
        //delete content from file
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

        //add two other functions ::
        //1--one for reading content from file 
        //2--for writing content into file

        //add two functions for datafile
        //1--serialization 
        //2--deserialization
        public byte[] SerializeDataFile(Models.File file)
        {

        }
    }

}

