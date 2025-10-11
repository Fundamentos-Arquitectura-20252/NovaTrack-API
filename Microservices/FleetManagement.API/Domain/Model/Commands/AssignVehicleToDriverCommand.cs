using NovaTrack.Shared.Domain.Model;

namespace NovaTrack.FleetManagement.Domain.Model.Commands
{
    public record AssignVehicleToDriverCommand(
        int VehicleId,
        int DriverId
    ) : ICommand<bool>;
}
