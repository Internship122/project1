using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Services.Personnes
{
    public interface IPersonneService: IDisposable
    {
        void CreatePersonne(Personne personne);

        Task<ActionResult<IEnumerable<Personne>>> GetAll();

        void PutPersonne(Personne personne);

        void Save();


    }
}
