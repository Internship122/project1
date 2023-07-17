using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personne.Repos.Models;

namespace Personne.Repos
{
    public class PersonneRepositry: GenericRepositry <Personne>, IPersonneRepositry

    {
        private readonly WebApplicationDbContext _db;

        public PersonneRepositry(WebApplicationDbContext db):base(options)
        {
            this._db = db;
        }

        public IEnumerable<Personne> PersonnesByAlphabetic
        {
            get
            {
                return (from m in this._db.Personnes 
                        orderby m.Name descending 
                        select m).Take(ALL);
            }
        }
    }
}
