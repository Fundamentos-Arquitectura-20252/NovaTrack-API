using NovaTrack.Shared.Domain.Model;

namespace NovaTrack.Personnel.Domain.Model.Commands
{
    public record RenewDriverLicenseCommand(
        int DriverId,
        string NewLicenseNumber,
        DateTime NewExpiryDate
    ) : ICommand<bool>;
}
