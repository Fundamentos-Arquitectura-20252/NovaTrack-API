using NovaTrack.FleetManagement.Domain.Model.Aggregates;
using NovaTrack.FleetManagement.Domain.Model.Commands;
using NovaTrack.FleetManagement.Interfaces.REST.Resources;

namespace NovaTrack.FleetManagement.Interfaces.REST.Transform
{
    public static class FleetResourceFromEntityAssembler
    {
        public static FleetResource ToResourceFromEntity(Fleet entity)
        {
            return new FleetResource(
                entity.Id,
                entity.Code,
                entity.Name,
                entity.Description,
                entity.Type.ToString(),
                entity.IsActive,
                entity.Vehicles.Count,
                entity.GetActiveVehicleCount(),
                entity.Vehicles.Count(v => v.Status == VehicleStatus.Maintenance),
                entity.GetPerformanceRate(),
                entity.CreatedAt,
                entity.UpdatedAt
            );
        }
    }
}
