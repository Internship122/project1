using WebApplication1.Data;
using WebApplication1.Migrations;
using HotChocolate.Data;
using HotChocolate;


namespace WebApplication1.GraphQl
{
    public class Mutation
    {
        public async Task<Models.File>AddFile([Service]ApplicationDbContext context, Models.File NewFile)
        {
            context.Files.Add(NewFile);
            await context.SaveChangesAsync();
            return NewFile;
        }

    }
}
