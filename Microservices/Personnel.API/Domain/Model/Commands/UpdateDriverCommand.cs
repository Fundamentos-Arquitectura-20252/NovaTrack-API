using NovaTrack.Personnel.Domain.Model.Aggregates;
using NovaTrack.Shared.Domain.Model;
using NovaTrack.Personnel.Domain.Model.ValueObjects;

namespace NovaTrack.Personnel.Domain.Model.Commands
{
    public record UpdateDriverCommand(
        int DriverId,
        string FirstName,
        string LastName,
        string LicenseNumber,
        DateTime LicenseExpiryDate,
        string Phone,
        string Email,
        int ExperienceYears,
        DriverStatus Status
    ) : ICommand<bool>;
}
