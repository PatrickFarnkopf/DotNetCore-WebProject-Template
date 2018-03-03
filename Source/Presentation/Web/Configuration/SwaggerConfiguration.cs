using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Presentation.Web.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void Configure(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", 
                new Info
                {
                    Title = "DefaultProject", Version = "v1"
                });
        }
    }
}