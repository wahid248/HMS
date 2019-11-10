﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Wahid.HMS.Core.Abstract.Repositories
{
    public interface IRepository<TEntity, T> where TEntity : class, IEntity<T>, new()
    {
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
        void Add(TEntity entity, string userId = null);
        void AddRange(IEnumerable<TEntity> entities, string userId = null);
        void Update(TEntity entity, string userId = null);
        void UpdateRange(IEnumerable<TEntity> entities, string userId = null);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> predicate);
        void DeleteRange(IEnumerable<TEntity> entities);
        void Archive(TEntity entity, string userId = null);
        void Archive(Expression<Func<TEntity, bool>> predicate, string userId = null);
        void ArchiveRange(IEnumerable<TEntity> entities, string userId = null);
        void Restore(TEntity entity, string userId = null);
        void Restore(Expression<Func<TEntity, bool>> predicate, string userId = null);
        void RestoreRange(IEnumerable<TEntity> entities, string userId = null);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task AddAsync(TEntity entity, string userId = null);
        Task AddRangeAsync(IEnumerable<TEntity> entities, string userId = null);
    }
}
