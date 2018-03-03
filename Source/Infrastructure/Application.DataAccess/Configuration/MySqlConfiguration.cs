using System;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Application.DataAccess.Configuration
{
    public class MySqlConfiguration
    {
        public QueryTrackingBehavior QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        
        public DbContextOptions GetDbContextOptions()
        {
            throw new NotImplementedException();
        }
    }
}