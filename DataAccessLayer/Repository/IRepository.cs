using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetOne(Expression<Func<TEntity, bool>> predicate = null);

        IEnumerable<TEntity> GetAll();

        void Remove(TEntity entity);

        void Add(TEntity entity);

        void Update(TEntity entity);
    }
}
