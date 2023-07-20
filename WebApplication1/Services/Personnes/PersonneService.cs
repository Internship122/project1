﻿using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace WebApplication1.Services.Personnes
{
    public class PersonneService : IPersonneService, IDisposable
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet dbSet;
        private bool _disposed;
        public PersonneService(ApplicationDbContext db, DbSet dbSet)
        {
            this._db = db;
            this.dbSet = dbSet;
        }
        public async void CreatePersonne(Personne personne)
        {
             _db.Personnes.Add(personne);
 
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _db.Dispose();
                if (disposing)
                { 
                _disposed = true;
                }
            }
            _db.Dispose(disposing);
        }

        public async Task<ActionResult<IEnumerable<Personne>>> GetAll()
        {
            return await _db.Personnes.
                OrderBy(p => p.Name).
                ThenBy(p => p.Prename).
                ToListAsync<Personne>();
        }

        public async void Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
