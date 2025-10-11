namespace NovaTrack.Personnel.Interfaces.REST.Resources
{
    public record RenewLicenseResource(
        string NewLicenseNumber,
        DateTime NewExpiryDate
    );
}
