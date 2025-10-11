namespace NovaTrack.Personnel.Interfaces.REST.Resources
{
    public record DriverListItemResource(
        int Id,
        string Code,
        string FullName,
        string Status,
        string LicenseNumber,
        bool IsLicenseExpiringSoon,
        int ExperienceYears,
        string? AssignedVehicle,
        bool IsActive
    );
}
