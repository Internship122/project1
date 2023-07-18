using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace WebApplication1.Services.Personnes
{
    public class PersonneService : IPersonneService, IDisposable
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet dbSet;
        public PersonneService(ApplicationDbContext db, DbSet dbSet)
        {
            this._db = db;
            this.dbSet = dbSet;
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


        public async void Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
