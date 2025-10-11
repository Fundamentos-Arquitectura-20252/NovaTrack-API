namespace NovaTrack.Personnel.Interfaces.REST.Resources
{
    public record UpdateDriverResource(
        string FirstName,
        string LastName,
        string LicenseNumber,
        DateTime LicenseExpiryDate,
        string Phone,
        string Email,
        int ExperienceYears,
        string Status
    );
}
