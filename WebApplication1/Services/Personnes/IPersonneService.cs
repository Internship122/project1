using WebApplication1.Models;

namespace WebApplication1.Services.Personnes
{
    public interface IPersonneService: IDisposable
    {
        void CreatePersonne(Personne personne);

        Task<IEnumerable<Personne>> GetAll();

        void PutPersonne(Personne personne);

        void Save();


    }
}
