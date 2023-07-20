using WebApplication1.Data;
using WebApplication1.Models;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core.Objects;

namespace WebApplication1.Services.Personnes
{
    public class PersonneService : IPersonneService
    {
        private readonly ApplicationDbContext _db;
   
        public PersonneService(ApplicationDbContext db)
        {
            this._db = db;
        }
        public async Task CreatePersonne(Personne personne)
        {
            await _db.Personnes.AddAsync(personne);
 
        }

      

        public async Task<IEnumerable<Personne>> GetAll()
        {
            return await _db.Personnes.
                 OrderBy(p => p.Name).
                 ThenBy(p => p.Prename).
                 ToListAsync<Personne>();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
