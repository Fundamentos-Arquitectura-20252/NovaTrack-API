using Flota365.Platform.API.FleetManagement.Domain.Model.Commands;
using Flota365.Platform.API.FleetManagement.Interfaces.REST.Resources;

namespace Flota365.Platform.API.FleetManagement.Interfaces.REST.Transform
{
    public static class UpdateMileageCommandFromResourceAssembler
    {
        public static UpdateVehicleMileageCommand ToCommandFromResource(int vehicleId, UpdateMileageResource resource)
        {
            return new UpdateVehicleMileageCommand(vehicleId, resource.NewMileage);
        }
    }
}
