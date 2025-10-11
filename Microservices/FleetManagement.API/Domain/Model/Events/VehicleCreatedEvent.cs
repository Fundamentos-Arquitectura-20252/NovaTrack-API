using NovaTrack.Shared.Domain.Model.Events;

namespace NovaTrack.FleetManagement.Domain.Model.Events
{
    public record VehicleCreatedEvent(
        int VehicleId,
        string LicensePlate,
        string Brand,
        string Model,
        DateTime CreatedAt
    ) : DomainEvent;
}
