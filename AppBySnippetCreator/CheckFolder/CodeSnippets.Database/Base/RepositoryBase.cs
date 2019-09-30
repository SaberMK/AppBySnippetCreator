using CodeSnippets.Database.Interfaces;
using CodeSnippets.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Database.Base
{
    public abstract class RepositoryBase<TEntity, TDbContext> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TDbContext : DbContext
    {
        protected DbSet<TEntity> Set => DbContext.Set<TEntity>();
        protected TDbContext DbContext => DbContextFactory.GetDbContext();
        protected IDbContextFactory<TDbContext> DbContextFactory { get; }


        protected RepositoryBase(IDbContextFactory<TDbContext> contextFactory)
        {
            DbContextFactory = contextFactory;
        }

        public TEntity GetById(long id)
        {
            return Set.FirstOrDefault(x => x.Id == id);
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await Set.FirstOrDefaultAsync(x => x.Id == id);
        }
        public TEntity Attach(long id)
        {
            return Attach(new TEntity { Id = id });
        }

        public TEntity Attach(TEntity entity)
        {
            return Set.Local.FirstOrDefault(x => x.Id == entity.Id) ??
                        Set.Attach(entity).Entity;
        }

        public IEnumerable<TEntity> Attach(IEnumerable<TEntity> entities)
        {
            return entities.Select(Attach).ToArray();
        }
        public TEntity Add(TEntity entity)
        {
            return Set.Add(entity).Entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var entityEntry = await Set.AddAsync(entity);
            return entityEntry.Entity;
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            Set.AddRange(entities);
        }

        public async Task AddAsync(IEnumerable<TEntity> entities)
        {
            await Set.AddRangeAsync(entities);
        }

        public TEntity Update(TEntity entity)
        {
            Attach(entity);
            var entry = DbContext.Entry(entity);
            entry.State = EntityState.Modified;
            return entry.Entity;
        }

        public IEnumerable<TEntity> Update(IEnumerable<TEntity> entities)
        {
            return entities.Select(Update).ToArray();
        }

        public TEntity AddOrUpdate(TEntity entity)
        {
            return entity.Id == 0 ? Add(entity) : Update(entity);
        }

        public IEnumerable<TEntity> AddOrUpdate(IEnumerable<TEntity> entities)
        {
            return entities.Select(AddOrUpdate).ToArray();
        }

        public TEntity Delete(TEntity entity)
        {
            return Set.Remove(entity).Entity;
        }
        public TEntity Delete(long id)
        {
            var entity = GetById(id);
            return Delete(entity);
        }
        public async Task<TEntity> DeleteAsync(long id)
        {
            var entity = await GetByIdAsync(id);

            if (entity != null)
                entity = Delete(entity);

            return entity;
        }
        
        public IEnumerable<TEntity> Delete(IEnumerable<TEntity> entities)
        {
            return entities.Select(Delete).ToArray();
        }

        public IQueryable<TEntity> Query()
        {
            return Set;
            
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public IIncludableQueryable<TEntity, TProperty> Include<TCEntity, TProperty>(
          Expression<Func<TEntity, TProperty>> navigationPropertyPath) 
            where TCEntity : class, IEntity, new()
            where TProperty : class, IEntity, new()

        {
            Set.Include(x => x.Id).ThenInclude(x => x.ToString());
            return default;
        }

        public IIncludableQueryable<TEntity, TProperty> ThenInclude<TCEntity, TPreviousProperty, TProperty>(
            Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath) where TCEntity : class, IEntity, new()
            where TProperty : class, IEntity, new()
            where TPreviousProperty : class, IEntity, new()
        {
            return default;
        }
    }
}
