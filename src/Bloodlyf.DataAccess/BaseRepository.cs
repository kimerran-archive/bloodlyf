using Bloodlyf.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloodlyf.DataAccess
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : Entity
    {
        private IUnitOfWork _uow;

        public BaseRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void Create(T entity)
        {
            _uow.Set<T>().Add(entity);
            _uow.Commit();
        }

        public T Find(int id)
        {
            return _uow.Set<T>().Where(o => o.Id == id).SingleOrDefault();
        }

        public IEnumerable<T> FindAll()
        {
            return _uow.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _uow.Set<T>().Attach(entity);
            _uow.Commit();
        }

        public void Delete(T entity)
        {
            _uow.Set<T>().Remove(entity);
            _uow.Commit();
        }
    }
}
