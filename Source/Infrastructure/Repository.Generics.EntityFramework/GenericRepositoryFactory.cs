using System;
using System.Collections.Generic;
using Infrastructure.Repository.Generics.Design;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Generics.EntityFramework
{
    public class GenericRepositoryFactory : IRepositoryFactory
    {
        private DbContext _dbContext;
        
        public GenericRepositoryFactory(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));
            
            _dbContext = dbContext;
        }

        public GenericRepositoryFactory() { }
        
        protected IDictionary<Type, object> RepositoryInstances;

        public void SetContext(DbContext dbContext)
        {
            if (_dbContext != null)
                throw new InvalidOperationException("DbContext is already initialized!");

            _dbContext = dbContext;
        }
        
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (RepositoryInstances == null)
                RepositoryInstances = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!RepositoryInstances.ContainsKey(type))
                RepositoryInstances[type] = new GenericRepository<TEntity>(_dbContext);

            return (IRepository<TEntity>)RepositoryInstances[type];
        }
    }
}