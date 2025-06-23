using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infra.Ioc.Config;

public static class ApiVersioningConfiguration
{
    public static void AddVersioning(this IServiceCollection services)
    {
        services
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
    }
}
