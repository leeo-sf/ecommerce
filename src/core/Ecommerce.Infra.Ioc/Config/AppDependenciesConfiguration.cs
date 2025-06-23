using Ecommerce.Domain.Api;
using Ecommerce.Domain.Handler;
using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain.Service;
using Ecommerce.Sharable.Config;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Ecommerce.Infra.Ioc.Config;

public static class AppDependenciesConfiguration
{
    public static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(opt => opt.RegisterServicesFromAssemblies(
            typeof(LoginRequestHandler).Assembly)
        );

        services.ConfigureRefitClient<IKeycloakApi>(configuration["KeycloakServer:Uri"]!);
        services.ConfigureAccessCredentials<KeycloakClientConfiguration>("KeycloakServer:App.Ecommerce", configuration);

        ConfigureServices(services);
    }

    private static void ConfigureRefitClient<T>(this IServiceCollection services, string host)
        where T : class
        => services.AddRefitClient<T>()
        .ConfigureHttpClient(httpClient =>
        {
            httpClient.BaseAddress = new Uri(host);
        });

    private static void ConfigureAccessCredentials<T>(this IServiceCollection services, string sectionName, IConfiguration configuration)
        where T : class
        => services.AddSingleton(opt =>
            configuration.GetSection(sectionName).Get<T>());

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IKeycloakApiService, KeycloakApiService>();
    }
}
