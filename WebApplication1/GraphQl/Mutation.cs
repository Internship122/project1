using WebApplication1.Data;
using WebApplication1.Migrations;
using HotChocolate.Data;
using HotChocolate;
using WebApplication1.Services.Files;
using HotChocolate.Execution;
using WebApplication1.Models;
using WebApplication1.Services.Personnes;

namespace WebApplication1.GraphQl
{
    public class Mutation
    {
        public async Task<PersonneDTO> AddPersonne([Service] IPersonneService personneService, Personne personne)
        {
            var NewPersonne = await personneService.CreatePersonne(personne);
            await personneService.Save();
            return NewPersonne;

        }
        public async Task<PersonneDTO> UpdatePersonne([Service] IPersonneService personneService, int id, Personne personne)
        {
            var ToUpdatePersonne = await personneService.UpdatePersonne(id, personne);
            if (ToUpdatePersonne == null)
            {
                throw new QueryException("Person Not Found");
            }
            else
            {
                await personneService.Save();
                return ToUpdatePersonne;
            }
        }
        public async Task<PersonneDTO> DeletPersonne([Service] IPersonneService personneService, int id)
        {
            var ToDeletePersonne = await personneService.DeletePersonne(id);
            if (ToDeletePersonne == null)
            {
                throw new QueryException("Person Not Found");
            }
            else
            {
                await personneService.Save();
                return ToDeletePersonne;
            }
        }
        public async Task<Models.File> AddFile([Service] IFileService fileService, IFormFile file)
        {
            var NewFile = await fileService.AddFile(file);
            await fileService.Save();
            return NewFile;
        }
        public async Task<Models.File> UpdateFile([Service] IFileService fileService, IFormFile file, string fileName)
        {
            var ToUpdateFile = await fileService.UpdateFile(file,fileName);
            if (ToUpdateFile == null) 
            {
                throw new QueryException("File Not Found");
            }
            else
            {
                await fileService.Save();
                return ToUpdateFile;
            }
        }
        public async Task<Models.File> DeleteFile([Service] IFileService fileService, string fileName)
        {
            var ToDeleteFile = await fileService.DeleteFile(fileName);
            if (ToDeleteFile == null)
            {
                throw new QueryException("File Not Found");
            }
            else
            {
                await fileService.Save();
                return ToDeleteFile;
            }
        }


    }
}
