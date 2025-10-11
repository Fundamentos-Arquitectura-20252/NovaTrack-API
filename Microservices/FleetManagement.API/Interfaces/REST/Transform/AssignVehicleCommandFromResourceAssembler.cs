using NovaTrack.FleetManagement.Domain.Model.Commands;
using NovaTrack.FleetManagement.Interfaces.REST.Resources;

namespace NovaTrack.FleetManagement.Interfaces.REST.Transform
{
    public static class AssignVehicleCommandFromResourceAssembler
    {
        public static AssignVehicleToFleetCommand ToFleetCommandFromResource(int vehicleId, AssignVehicleToFleetResource resource)
        {
            return new AssignVehicleToFleetCommand(vehicleId, resource.FleetId);
        }

        public static AssignVehicleToDriverCommand ToDriverCommandFromResource(int vehicleId, AssignVehicleToDriverResource resource)
        {
            return new AssignVehicleToDriverCommand(vehicleId, resource.DriverId);
        }
    }
}
