using Microsoft.Extensions.DependencyInjection;
using NovaTrack.FleetManagement.Domain.Repositories;
using NovaTrack.FleetManagement.Infrastructure.Persistence.EFC.Repositories;

namespace NovaTrack.FleetManagement.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFleetManagementServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IFleetRepository, FleetRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();
            
            return services;
        }
    }
}