using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generics.Design
{
    public interface IRepository<TEntity> where TEntity: class
    {
        int Count(Expression<Func<TEntity, bool>> predicate = null);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null);
        
        bool Any(Expression<Func<TEntity, bool>> predicate = null);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null);
        
        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);
        
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate);
    }
}