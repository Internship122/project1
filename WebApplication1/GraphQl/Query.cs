using HotChocolate;
using HotChocolate.Data;
using System.Data.Entity;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.GraphQl
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Personne> GetPersonnes([Service] ApplicationDbContext context) =>
             context.Personnes;
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Models.File> GetFiles([Service] ApplicationDbContext context) =>
            context.Files;
    }
}
