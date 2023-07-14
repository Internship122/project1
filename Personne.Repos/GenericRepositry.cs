
using Personne.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personne.Repos
{
    public class GenericRepositry<T> : IRepositry<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _dbSet;

        public GenericRepositry(ApplicationDbContext context)
        {
            this._db = context;
            this._dbSet=this._db.Set<T>();
        }
        public void Add(T entity)
        {
            this._dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return this._dbSet.ToList();
        }

        public void Save(T entity)
        {
            this._dbSet.Attach(entity);
            this._db.Entry(entity).State = EntityState.Modified;
        }
    }
}
