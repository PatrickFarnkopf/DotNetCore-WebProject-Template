using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWork.EntityFramework
{
    public abstract class AbstractUnitOfWork<TContext> : 
        IUnitOfWorkEntityFramework<TContext>, IDisposable where TContext: DbContext
    {
        protected readonly TContext DbContext;

        private bool _isDisposed;
        
        public AbstractUnitOfWork(TContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException(nameof(dbContext));
            
            DbContext = dbContext;
        }

        public int Commit(bool ensureAutoHistory = false)
        {
            if (ensureAutoHistory)
                DbContext.EnsureAutoHistory();
            return DbContext.SaveChanges();
        }

        public async Task<int> CommitAsync(bool ensureAutoHistory = false)
        {
            if (ensureAutoHistory)
                DbContext.EnsureAutoHistory();
            return await DbContext.SaveChangesAsync();
        }

        public virtual int ExecuteQuery(string sql, params object[] parameters) 
            => DbContext.Database.ExecuteSqlCommand(sql, parameters);
        
        public virtual async Task<int> ExecuteQueryAsync(string sql, params object[] parameters) 
            => await DbContext.Database.ExecuteSqlCommandAsync(sql, parameters);
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;
            
            if (disposing)
                DbContext.Dispose();

            _isDisposed = true;
        }
    }
}