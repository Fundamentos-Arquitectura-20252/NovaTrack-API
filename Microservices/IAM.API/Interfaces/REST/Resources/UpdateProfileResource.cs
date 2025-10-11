namespace NovaTrack.IAM.Interfaces.REST.Resources
{
    public record UpdateProfileResource(
        string FirstName,
        string LastName,
        string Email
    );
}