using WebApplication1.Models;

namespace WebApplication1.Services.Personnes
{
    public interface IPersonneService: IDisposable
    {
        void CreatePersonne(Personne personne);

        IEnumerable<Personne> GetAll();

        void Save();
    }
}
