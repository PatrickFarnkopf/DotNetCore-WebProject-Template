using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Application.DataAccess.Configuration
{
    public class InMemoryConfiguration : IContextConfiguration
    {
        public string DatabaseName = "Default";
        public QueryTrackingBehavior QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        
        public DbContextOptions GetDbContextOptions()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(DatabaseName);
            builder.UseQueryTrackingBehavior(QueryTrackingBehavior);
            return builder.Options;
        }
    }
}