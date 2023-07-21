using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core.Objects;
using WebApplication1.Models;

namespace WebApplication1.Services.Personnes
{
    public interface IPersonneService
    {
        Task CreatePersonne(Personne personne);

        Task<IEnumerable<PersonneDTO>> GetAll(); 

        Task Save();

        bool AgeValidator(Personne personne,int MaxAge, int MinAge);
    }
}
