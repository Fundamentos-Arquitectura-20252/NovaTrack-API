using NovaTrack.Shared.Domain.Model;

namespace NovaTrack.FleetManagement.Domain.Model.Commands
{
    public record CreateVehicleCommand(
        string LicensePlate,
        string Brand, 
        string Model,
        int Year,
        int Mileage,
        int? FleetId,
        int? DriverId
    ) : ICommand<int>;
}
