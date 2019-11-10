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

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(x => x.IsArchived == false).Where(predicate).FirstOrDefault();
        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
        {
            return _dbSet.Where(x => x.IsArchived == false).Where(predicate).ToList();
        }
        public void Add(TEntity entity, string userId = null)
        {
            entity.CreatedOn = _currentDateTime;
            entity.CreatedBy = userId;
            _dbSet.Add(entity);
        }
        public void AddRange(IEnumerable<TEntity> entities, string userId = null)
        {
            foreach (var entity in entities)
            {
                entity.CreatedOn = _currentDateTime;
                entity.CreatedBy = userId;
            }
            _dbSet.AddRange(entities);
        }
        public void Update(TEntity entity, string userId = null)
        {
            entity.ModifiedOn = _currentDateTime;
            entity.ModifiedBy = userId;
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public void UpdateRange(IEnumerable<TEntity> entities, string userId = null)
        {
            foreach (var entity in entities)
            {
                entity.ModifiedOn = _currentDateTime;
                entity.ModifiedBy = userId;
            }
            _dbContext.AttachRange(entities);
            foreach (var entity in entities)
                _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(TEntity entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }
        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = _dbSet.Where(predicate).ToList();
            DeleteRange(entities);
        }
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbContext.AttachRange(entities);
            foreach (var entity in entities)
                _dbContext.Entry(entity).State = EntityState.Deleted;
        }
        public void Archive(TEntity entity, string userId = null)
        {
            entity.IsArchived = true;
            entity.ModifiedOn = _currentDateTime;
            entity.ModifiedBy = userId;
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public void Archive(Expression<Func<TEntity, bool>> predicate, string userId = null)
        {
            var entities = _dbSet.Where(predicate).ToList();
            entities.ForEach(p => { p.IsArchived = true; p.ModifiedOn = _currentDateTime; p.ModifiedBy = userId; });
            ArchiveRange(entities, userId);
        }
        public void ArchiveRange(IEnumerable<TEntity> entities, string userId = null)
        {
            entities.ToList().ForEach(p => { p.IsArchived = true; p.ModifiedOn = _currentDateTime; p.ModifiedBy = userId; });
            _dbContext.AttachRange(entities);
            foreach (var entity in entities)
                _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public void Restore(TEntity entity, string userId = null)
        {
            entity.IsArchived = false;
            entity.ModifiedOn = _currentDateTime;
            entity.ModifiedBy = userId;
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public void Restore(Expression<Func<TEntity, bool>> predicate, string userId = null)
        {
            var entities = _dbSet.Where(predicate).ToList();
            entities.ForEach(p => { p.IsArchived = false; p.ModifiedOn = _currentDateTime; p.ModifiedBy = userId; });
            RestoreRange(entities, userId);
        }
        public void RestoreRange(IEnumerable<TEntity> entities, string userId = null)
        {
            entities.ToList().ForEach(p => { p.IsArchived = false; p.ModifiedOn = _currentDateTime; p.ModifiedBy = userId; });
            _dbContext.AttachRange(entities);
            foreach (var entity in entities)
                _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(x => x.IsArchived == false).Where(predicate).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            return await _dbSet.Where(x => x.IsArchived == false).Where(predicate).ToListAsync();
        }
        public async Task AddAsync(TEntity entity, string userId = null)
        {
            entity.CreatedOn = _currentDateTime;
            entity.CreatedBy = userId;
            await _dbSet.AddAsync(entity);
        }
        public async Task AddRangeAsync(IEnumerable<TEntity> entities, string userId = null)
        {
            foreach (var entity in entities)
            {
                entity.CreatedOn = _currentDateTime;
                entity.CreatedBy = userId;
            }
            await _dbSet.AddRangeAsync(entities);
        }
    }
}