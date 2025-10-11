using NovaTrack.Shared.Domain.Model;

namespace NovaTrack.FleetManagement.Domain.Model.Commands
{
    public record AssignVehicleToFleetCommand(
        int VehicleId,
        int FleetId
    ) : ICommand<bool>;
}
