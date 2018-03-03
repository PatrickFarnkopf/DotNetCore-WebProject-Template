using Infrastructure.Application.DataAccess.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Application.DataAccess
{
    public class Context : DbContext
    {
        public Context(IContextConfiguration configuration) : base(configuration.GetDbContextOptions()) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExampleModelConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}