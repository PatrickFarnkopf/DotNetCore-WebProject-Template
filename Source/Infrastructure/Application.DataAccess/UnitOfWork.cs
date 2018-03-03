using Infrastructure.UnitOfWork.EntityFramework;

namespace Infrastructure.Application.DataAccess
{
    public class UnitOfWork : AbstractUnitOfWork<Context>
    {
        public UnitOfWork(Context dbContext) : base(dbContext)
        {
        }
    }
}