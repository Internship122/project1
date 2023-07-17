using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services.Personnes
{
    public class PersonneService : IPersonneService, IDisposable
    {
        private readonly ApplicationDbContext _db;
        //public PersonneService(ApplicationDbContext db)
        //{
        //    this._db = db;
        //}
        public void Add(Personne personne)
        {
            _db.Personnes.Add(personne);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> GetAll()
        {
            return _db.Personnes.ToList<Personne>();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
