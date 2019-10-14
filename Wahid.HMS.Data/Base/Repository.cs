using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Wahid.HMS.Core.Abstract;
using Wahid.HMS.Core.Abstract.Repositories;

namespace Wahid.HMS.Data.Base
{
    public class Repository<TEntity, T> : IRepository<TEntity, T> where TEntity : class, IEntity<T>, new()
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        private readonly DateTime _currentDateTime;

        public Repository(DataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
            _currentDateTime = DateTime.UtcNow;
        }

        public void Add(TEntity entity)
        {
            entity.CreatedOn = _currentDateTime;
            _dbSet.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            entity.CreatedOn = _currentDateTime;
            await _dbSet.AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                entity.CreatedOn = _currentDateTime;
            _dbSet.AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                entity.CreatedOn = _currentDateTime;
            await _dbSet.AddRangeAsync(entities);
        }

        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.ModifiedOn = _currentDateTime;
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void DeletePermanently(TEntity entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                entity.ModifiedOn = _currentDateTime;
            }
            _dbContext.AttachRange(entities);
            foreach (var entity in entities)
                _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AsQueryable().Where(x => x.IsDeleted == false).Where(predicate).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
           return _dbSet.AsQueryable().Where(x => x.IsDeleted == false).Where(predicate).ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await _dbSet.AsQueryable().Where(x => x.IsDeleted == false).Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsQueryable().Where(x => x.IsDeleted == false).Where(predicate).FirstOrDefaultAsync();
        }

        public void Update(TEntity entity)
        {
            entity.ModifiedOn = _currentDateTime;
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
                entity.ModifiedOn = _currentDateTime;
            _dbContext.AttachRange(entities);
            foreach (var entity in entities)
                _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
