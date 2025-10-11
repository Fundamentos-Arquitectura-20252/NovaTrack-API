using NovaTrack.Shared.Domain.Model;

namespace NovaTrack.FleetManagement.Domain.Model.Commands
{
    public record UpdateVehicleMileageCommand(
        int VehicleId,
        int NewMileage
    ) : ICommand<bool>;
}
