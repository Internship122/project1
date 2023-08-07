using HotChocolate;
using HotChocolate.Data;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Personne> GetPersonnes([Service] ApplicationDbContext context)=>
            context.Personnes;
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Models.File> GetFiles([Service] ApplicationDbContext context)=>
            context.Files;
    }
}
