using MovieListingsApp.Core.Contracts.Repositories;
using MovieListingsApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieListingsApp.Repositories
{
    public abstract class BaseRepository<T> : IGenericRepository<T>, IGenericRepositoryAsync<T> where T : class
    {
        protected MovieListingsDbContext _context;
        protected readonly DbSet<T> _entities = null;

        public BaseRepository(MovieListingsDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        #region Sync methods

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T GetById(object id)
        {
            return _entities.Find(id);
        }

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate).AsEnumerable();
        }

        public T Add(T entity)
        {
            return _entities.Add(entity);
        }

        public T Remove(object id)
        {
            T existingEntity = _entities.Find(id);
            return _entities.Remove(existingEntity);
        }

        public void Update(T entity)
        {
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        #endregion

        /// Async Methods ///

        #region Async Methods

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<T> RemoveAsync(object id)
        {
            T existingEntity = await _entities.FindAsync(id);
            return _entities.Remove(existingEntity);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #endregion
    }
}
