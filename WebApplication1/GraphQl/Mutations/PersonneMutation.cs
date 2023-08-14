using HotChocolate.Execution;
using WebApplication1.Models;
using WebApplication1.Services.Personnes;

namespace WebApplication1.GraphQl.Mutations
{
    public class PersonneMutation
    {
        private readonly IPersonneService _personneService;
        public PersonneMutation(IPersonneService personneService)
        {
            _personneService = personneService;
        }
        public async Task<PersonneDTO> AddPersonne(Personne personne)
        {
            var NewPersonne = await _personneService.CreatePersonne(personne);
            await _personneService.Save();
            return NewPersonne;

        }
        public async Task<PersonneDTO> UpdatePersonne(int id, Personne personne)
        {
            var ToUpdatePersonne = await _personneService.UpdatePersonne(id, personne);
            if (ToUpdatePersonne == null)
            {
                throw new QueryException("Person Not Found");
            }
            else
            {
                await _personneService.Save();
                return ToUpdatePersonne;
            }
        }
        public async Task<PersonneDTO> DeletPersonne(int id)
        {
            var ToDeletePersonne = await _personneService.DeletePersonne(id);
            if (ToDeletePersonne == null)
            {
                throw new QueryException("Person Not Found");
            }
            else
            {
                await _personneService.Save();
                return ToDeletePersonne;
            }
        }
    }
}
