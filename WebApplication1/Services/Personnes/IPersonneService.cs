using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core.Objects;
using WebApplication1.Models;

namespace WebApplication1.Services.Personnes
{
    public interface IPersonneService: IDisposable
    {
        void CreatePersonne(Personne personne);

        Task<ActionResult<IEnumerable<Personne>>> GetAll();

        void Save();


    }
}
