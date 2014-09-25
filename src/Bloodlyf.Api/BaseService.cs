using Bloodlyf.DataAccess;
using Bloodlyf.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloodlyf.Api
{
    public class BaseService<T> : IBaseService<T>
        where T: Entity
    {
        private IBaseRepository<T> _repository;
        public BaseService(IBaseRepository<T> repository) 
        {
            _repository = repository;
        }

        public T Create(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            _repository.Create(entity);

            return this.Find(entity.Id);
        }

        public T Find(int id)
        {
            return _repository.Find(id);
        }

        public IEnumerable<T> FindAll()
        {
            return _repository.FindAll();
        }

        public void Update(T entity)
        {
            entity.ModifiedAt = DateTime.Now;
             _repository.Update(entity);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }
    }
}
