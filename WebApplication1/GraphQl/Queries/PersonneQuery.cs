using WebApplication1.Models;
using WebApplication1.Services.Personnes;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.AspNetCore;
using WebApplication1.Data;

namespace WebApplication1.GraphQl.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class PersonneQuery
    {
        private readonly IPersonneService _personneService;
        public PersonneQuery(IPersonneService personneService)
        {
            _personneService = personneService;
        }
        [UseDbContext(typeof(ApplicationDbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<PersonneType> GetPersonnes([Service] ApplicationDbContext context)
        {
            return context.Personnes.Select(p => new PersonneType()
            {
                Id = p.Id,
                Name = p.Name,
                Prename = p.Prename,
                Age = p.Age(p.BirthDate),
            }); ;
        }
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<PersonneType?> GetPersonneById(int id, [Service] ApplicationDbContext context)
        {
            Personne personne = await context.Personnes.FindAsync(id);

            if (personne == null)
            {
                return null;
            }

            return new PersonneType()
            {
                Id= personne.Id,
                Name = personne.Name,
                Prename = personne.Prename,
                Age=personne.Age(personne.BirthDate)
            };
        }
    }
}
