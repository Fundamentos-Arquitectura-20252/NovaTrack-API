using Microsoft.Extensions.DependencyInjection;
using NovaTrack.IAM.Domain.Repositories;
using NovaTrack.IAM.Infrastructure.Persistence.EFC.Repositories;

namespace NovaTrack.IAM.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIAMServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            
            return services;
        }
    }
}