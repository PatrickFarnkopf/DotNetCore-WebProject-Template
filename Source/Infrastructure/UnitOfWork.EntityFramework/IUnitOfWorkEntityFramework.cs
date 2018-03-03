using System.Threading.Tasks;
using Infrastructure.UnitOfWork.Design;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWork.EntityFramework
{
    public interface IUnitOfWorkEntityFramework<TContext> : IUnitOfWork where TContext: DbContext
    {
        int ExecuteQuery(string sql, params object[] parameters);
        Task<int> ExecuteQueryAsync(string sql, params object[] parameters);
    }
}