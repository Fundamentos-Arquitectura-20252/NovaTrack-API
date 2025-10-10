using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Flota365.Platform.API.Shared.Domain.Model.Events;
using Flota365.Platform.API.Shared.Domain.Repositories;
using Flota365.Platform.API.Shared.Infrastructure.Configuration;
using Flota365.Platform.API.Shared.Infrastructure.Events;
using Flota365.Platform.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Flota365.Platform.API.Shared.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            services.Configure<ApplicationSettings>(configuration => { });
            services.Configure<DatabaseSettings>(configuration => { });
            services.Configure<CachingSettings>(configuration => { });
            services.Configure<LoggingSettings>(configuration => { });

            return services;
        }

        public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApplicationSettings>(configuration.GetSection("Application"));
            services.Configure<DatabaseSettings>(configuration.GetSection("Database"));
            services.Configure<CachingSettings>(configuration.GetSection("Caching"));
            services.Configure<LoggingSettings>(configuration.GetSection("Logging"));

            services.AddSharedServices();
            services.AddMemoryCache();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}