using WebApplication1.Models;

namespace WebApplication1.Services.Personnes
{
    public interface IPersonneService: IDisposable
    {
        void Add(Personne personne);

        IEnumerable<Personne> GetAll();

        void Save();
    }
}
