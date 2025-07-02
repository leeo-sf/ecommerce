using Ecommerce.Domain.Interfaces;
using Ecommerce.Domain;
using Ecommerce.Domain.Interface;
using Ecommerce.Data;
using Ecommerce.Data.Repository;
using Ecommerce.Sharable.Config;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Ecommerce.Domain.Contracts.Apis;
using Ecommerce.Domain.Contracts.Service;

namespace Ecommerce.Infra.Ioc.Config;

public static class AppDependenciesConfiguration
{
    public static void ConfigureAppDependencies(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddMediatR(opt =>
            opt.RegisterServicesFromAssemblies(typeof(DomainAssemblyReference).Assembly)
        );

        services.ConfigureRefitClient<IKeycloakApi>(configuration["KeycloakServer:Uri"]!);
        services.ConfigureAccessCredentials<KeycloakClientConfiguration>(
            "KeycloakServer:App.Ecommerce",
            configuration
        );

        services.AddSingleton(AutoMapperConfiguration.RegisterMaps().CreateMapper());

        ConfigureServices(services);
        ConfigureDbContext(services, configuration);
    }

    private static void ConfigureRefitClient<T>(this IServiceCollection services, string host)
        where T : class =>
        services
            .AddRefitClient<T>()
            .ConfigureHttpClient(httpClient =>
            {
                httpClient.BaseAddress = new Uri(host);
            });

    private static void ConfigureAccessCredentials<T>(
        this IServiceCollection services,
        string sectionName,
        IConfiguration configuration
    )
        where T : class =>
        services.AddSingleton(opt => configuration.GetSection(sectionName).Get<T>());

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IKeycloakApiService, KeycloakApiService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
    }

    private static void ConfigureDbContext(
        IServiceCollection services,
        IConfiguration configuration
    ) =>
        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseNpgsql(configuration["ConnectionStrings:database"]!);
        });
}
