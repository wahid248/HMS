using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Wahid.HMS.Core.Abstract.Repositories
{
    public interface IRepository<TEntity, T> where TEntity : class, IEntity<T>, new()
    {
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
    }
}
