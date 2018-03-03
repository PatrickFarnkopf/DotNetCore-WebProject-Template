using Infrastructure.Repository.Generics.EntityFramework;
using Infrastructure.Application.Repository.Design;
using Domain.Entity.Model;

namespace Infrastructure.Application.DataAccess.Repositories
{
    public class ExampleModelRepository : GenericRepository<ExampleModel>, IExampleModelRepository
    {
        public ExampleModelRepository(Context dbContext) : base(dbContext) { }
    }
}
