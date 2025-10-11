using NovaTrack.FleetManagement.Domain.Model.Commands;
using NovaTrack.FleetManagement.Interfaces.REST.Resources;

namespace NovaTrack.FleetManagement.Interfaces.REST.Transform
{
    public static class UpdateMileageCommandFromResourceAssembler
    {
        public static UpdateVehicleMileageCommand ToCommandFromResource(int vehicleId, UpdateMileageResource resource)
        {
            return new UpdateVehicleMileageCommand(vehicleId, resource.NewMileage);
        }
    }
}
