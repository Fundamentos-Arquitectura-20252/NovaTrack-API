using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using NovaTrack.Maintenance.Domain.Model.Commands;
using NovaTrack.Maintenance.Domain.Model.Queries;
using NovaTrack.Maintenance.Interfaces.REST.Resources;
using NovaTrack.Maintenance.Domain.Repositories;
using NovaTrack.Maintenance.Infrastructure.Persistence.EFC.Repositories;


// ServiceCollectionExtensions.cs
namespace NovaTrack.Maintenance.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMaintenanceServices(this IServiceCollection services)
        {
            // Repositories would be registered here when implemented
             services.AddScoped<IMaintenanceRecordRepository, MaintenanceRecordRepository>();
             services.AddScoped<IServiceRecordRepository, ServiceRecordRepository>();
            
            return services;
        }
    }
}