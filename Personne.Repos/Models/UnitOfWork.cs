using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personne.Repos.Contracts;
using WebApplication1.Data;
using Personne.Repos.Models;

namespace Personne.Repos.Models
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public PersonneRepositry PersonneRepositry { get; set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            this._db = db;
            this.PersonneRepositry = new PersonneRepositry(this._db);
        }

        public void Dispose()
        {
            this._db.Dispose();
        }

        public async Task commit()
        {
            await this._db.SaveChangesAsync();
        }
    }
}
