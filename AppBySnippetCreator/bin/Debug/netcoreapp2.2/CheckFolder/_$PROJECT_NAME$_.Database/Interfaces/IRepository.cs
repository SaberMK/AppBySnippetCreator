using _$PROJECT_NAME$_.Entities.Interfaces;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _$PROJECT_NAME$_.Database.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity GetById(long id);

        Task<TEntity> GetByIdAsync(long id);

        TEntity Attach(long id);

        TEntity Attach(TEntity entity);

        IEnumerable<TEntity> Attach(IEnumerable<TEntity> entities);

        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity);
        
        void Add(IEnumerable<TEntity> entities);

        Task AddAsync(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

        IEnumerable<TEntity> Update(IEnumerable<TEntity> entities);

        TEntity AddOrUpdate(TEntity entity);

        IEnumerable<TEntity> AddOrUpdate(IEnumerable<TEntity> entities);

        TEntity Delete(TEntity entity);

        TEntity Delete(long id);

        Task<TEntity> DeleteAsync(long id);

        IEnumerable<TEntity> Delete(IEnumerable<TEntity> entities);

        IQueryable<TEntity> Query();

        

        void Commit();

        Task CommitAsync();
    }
}
