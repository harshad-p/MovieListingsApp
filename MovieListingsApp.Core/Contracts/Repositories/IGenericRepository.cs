using System.Collections.Generic;

namespace MovieListingsApp.Core.Contracts.Repositories
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        T Add(T entity);
        void Update(T entity);
        T Remove(object id);
        int Save();
    }
}