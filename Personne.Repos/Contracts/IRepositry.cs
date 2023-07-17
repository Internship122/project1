using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personne.Repos.Contracts
{
    public interface IRepositry<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Add(T entity);

        void Save(T entity);

    }
}
