using NovaTrack.FleetManagement.Domain.Model.Aggregates;
using NovaTrack.Shared.Domain.Model;
using NovaTrack.FleetManagement.Domain.Model.ValueObjects;

namespace NovaTrack.FleetManagement.Domain.Model.Commands
{
    public record UpdateVehicleCommand(
        int VehicleId,
        string LicensePlate,
        string Brand,
        string Model,
        int Year,
        int Mileage,
        VehicleStatus Status,
        int? FleetId,
        int? DriverId,
        DateTime? LastServiceDate,
        DateTime? NextServiceDate
    ) : ICommand<bool>;
}
