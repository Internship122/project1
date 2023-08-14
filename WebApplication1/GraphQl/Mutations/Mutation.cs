using WebApplication1.Data;
using WebApplication1.Migrations;
using HotChocolate.Data;
using HotChocolate;
using WebApplication1.Services.Files;
using HotChocolate.Execution;
using WebApplication1.Models;
using WebApplication1.Services.Personnes;
using HotChocolate.Data.Filters;
using HotChocolate.Types;

namespace WebApplication1.GraphQl.Mutations
{
    public class Mutation : ObjectType<Mutation>

    {
        
        //protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        //{
        //    descriptor.Field("addPersonne")
        //        .Argument("personne", arg => arg.Type<NonNullType<PersonneInputType>>())
        //        .Resolve(async context =>
        //        {
        //            var personne = context.ArgumentValue<Personne>("personne");
        //            var newPersonne = await _personneService.CreatePersonne(personne);
        //            await _personneService.Save();
        //            return newPersonne;
        //        });
        //    descriptor
        //    .Field("uploadFile")
        //    .Argument("file", a => a.Type<FileInputType>())
        //    .Resolve(async context =>
        //    {
        //        var file = context.ArgumentValue<IFormFile>("file");

        //        await using Stream stream = file.OpenReadStream();

        //        var fileName = file.Name;
        //        var fileContent = _fileService.GetFileBytes(file);

        //        var savedFile = await _fileService.AddFile(file);
        //        await _fileService.Save();
        //        return savedFile;
        //    });
        //}
    }
}
