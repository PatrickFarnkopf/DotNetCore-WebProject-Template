using Infrastructure.Application.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Web.Configuration
{
    public static class EntityFrameworkConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddDbContext<Context>(options => options.UseInMemoryDatabase("defaultDatabase"));
        }
    }
}