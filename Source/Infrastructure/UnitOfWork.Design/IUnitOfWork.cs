using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork.Design
{
    public interface IUnitOfWork
    {
        int Commit(bool ensureAutoHistory = false);
        Task<int> CommitAsync(bool ensureAutoHistory = false);
    }
}