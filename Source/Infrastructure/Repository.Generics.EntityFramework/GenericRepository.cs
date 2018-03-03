using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Infrastructure.Repository.Generics.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Repository.Generics.EntityFramework
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        protected readonly DbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        public GenericRepository(DbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            DbSet = DbContext.Set<TEntity>();
        }
        
        public virtual int Count(Expression<Func<TEntity, bool>> predicate = null) => DbSet.Count(predicate);
        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null) => await DbSet.CountAsync(predicate);
        public virtual bool Any(Expression<Func<TEntity, bool>> predicate = null) => DbSet.Any(predicate);
        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null) => await DbSet.AnyAsync(predicate);

        public void Insert(TEntity entity) => DbSet.Add(entity);
        public void Insert(IEnumerable<TEntity> entities) => DbSet.AddRange(entities);
        public void Update(TEntity entity) => DbSet.Update(entity);
        public void Update(IEnumerable<TEntity> entities) => DbSet.UpdateRange(entities);
        public void Delete(TEntity entity) => DbSet.Remove(entity);
        public void Delete(IEnumerable<TEntity> entities) => DbSet.RemoveRange(entities);

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = DbSet;
            
            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                return orderBy(query).FirstOrDefault();
            
            return query.FirstOrDefault();
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            IQueryable<TEntity> query = DbSet;
            
            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).FirstOrDefaultAsync();
            
            return await query.FirstOrDefaultAsync();
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return new Task<IEnumerable<TEntity>>(() => DbSet.Where(predicate));
        }
    }
}