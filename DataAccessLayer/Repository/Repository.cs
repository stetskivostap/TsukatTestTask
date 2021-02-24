using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }        

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public TEntity GetOne(Expression<Func<TEntity, bool>> predicate = null)
        {
            var entity = _dbSet.Where(predicate).SingleOrDefault();
            return entity;
        }

        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
