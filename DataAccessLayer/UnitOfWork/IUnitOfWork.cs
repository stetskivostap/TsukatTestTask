using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChanges();

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
