using Infrastructure.Application.DataAccess;
using Infrastructure.Application.DataAccess.Configuration;
using Infrastructure.UnitOfWork.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Web.Configuration
{
    public static class DependencyInjectorConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IContextConfiguration, InMemoryConfiguration>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}