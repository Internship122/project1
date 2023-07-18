using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Services.Personnes
{
    public class PersonneService : IPersonneService, IDisposable
    {
        private readonly ApplicationDbContext _db;
        public PersonneService(ApplicationDbContext db)
        {
            this._db = db;
        }
        public async void CreatePersonne(Personne personne)
        {
            _db.Personnes.Add(personne);
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<Personne>>> GetAll()
        {
            return await _db.Personnes.ToListAsync<Personne>();
        }

        public async void PutPersonne(Personne personne)
        {
            await _db.SaveChangesAsync();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
