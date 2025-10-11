using NovaTrack.Shared.Domain.Model;

namespace NovaTrack.Personnel.Domain.Model.Commands
{
    public record RegisterDriverCommand(
        string Code,
        string FirstName,
        string LastName,
        string LicenseNumber,
        DateTime LicenseExpiryDate,
        string Phone,
        string Email,
        int ExperienceYears
    ) : ICommand<int>;
}
