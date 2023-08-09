using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core.Objects;
using WebApplication1.Models;

namespace WebApplication1.Services.Personnes
{
    public interface IPersonneService
    {
        Task<PersonneDTO> CreatePersonne(Personne personne);

        Task<IEnumerable<PersonneDTO>> GetAll(); 

        Task<PersonneDTO?> GetById(int id);

        Task<PersonneDTO?> UpdatePersonne(int id,Personne personne);

        Task<PersonneDTO?> DeletePersonne(int id);

        Task Save();

        bool AgeValidator(Personne personne,int MaxAge, int MinAge);
    }
}
