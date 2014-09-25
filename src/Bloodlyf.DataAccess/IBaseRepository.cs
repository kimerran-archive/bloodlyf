using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloodlyf.DataAccess
{
    public interface IBaseRepository<T>
    {
        void Create(T entity);
        T Find(int id);
        IEnumerable<T> FindAll();
        void Update(T entity);
        void Delete(T entity);
    }
}
