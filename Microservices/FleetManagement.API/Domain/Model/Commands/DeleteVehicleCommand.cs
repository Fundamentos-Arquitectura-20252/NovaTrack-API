using NovaTrack.Shared.Domain.Model;

namespace NovaTrack.FleetManagement.Domain.Model.Commands
{
    public record DeleteVehicleCommand(
        int VehicleId
    ) : ICommand<bool>;
}
