using WebApplication1.Data;
using WebApplication1.Migrations;
using HotChocolate.Data;
using HotChocolate;
using WebApplication1.Services.Files;
using HotChocolate.Execution;
using WebApplication1.Models;
using WebApplication1.Services.Personnes;
using HotChocolate.Data.Filters;

namespace WebApplication1.GraphQl
{
    public class Mutation : ObjectType<Mutation>
        
    {
        private readonly FileService fileService1;
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
        //protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        //{
        //    descriptor
        //    .Field("uploadFile")
        //    .Argument("file", a => a.Type<UploadType>())
        //    .Resolve(async context =>
        //    {
        //        var file = context.ArgumentValue<IFormFile>("file");

        //        var fileName = file.Name;
        //        var fileContent = fileService1.GetFileBytes(file);

        //        await using Stream stream = file.OpenReadStream();
        //    });
        //}
        //public async Task<Models.File> AddFile([Service] IFileService fileService, FileInputType file)
        //{
        //    var NewFile = await fileService.AddFile((IFormFile)file);
        //    await fileService.Save();
        //    return NewFile;
        //}
        //public async Task<Models.File> UpdateFile([Service] IFileService fileService, FileInputType file, string fileName)
        //{
        //    var ToUpdateFile = await fileService.UpdateFile((IFormFile)file, fileName);
        //    if (ToUpdateFile == null)
        //    {
        //        throw new QueryException("File Not Found");
        //    }
        //    else
        //    {
        //        await fileService.Save();
        //        return ToUpdateFile;
        //    }
        //}
        //public async Task<Models.File> DeleteFile([Service] IFileService fileService, string fileName)
        //{
        //    var ToDeleteFile = await fileService.DeleteFile(fileName);
        //    if (ToDeleteFile == null)
        //    {
        //        throw new QueryException("File Not Found");
        //    }
        //    else
        //    {
        //        await fileService.Save();
        //        return ToDeleteFile;
        //    }
        //}


    }
}
