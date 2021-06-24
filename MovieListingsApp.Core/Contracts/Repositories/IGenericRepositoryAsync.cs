using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieListingsApp.Core.Contracts.Repositories
{
    public interface IGenericRepositoryAsync<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        //Task<T> AddAsync(T entity);
        Task<T> RemoveAsync(object id);
        Task<int> SaveAsync();
    }
}