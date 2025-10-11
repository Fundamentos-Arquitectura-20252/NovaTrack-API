using NovaTrack.Shared.Domain.Model;

namespace NovaTrack.IAM.Domain.Model.Commands
{
    public record UpdateUserProfileCommand(
        int UserId,
        string FirstName,
        string LastName,
        string Email
    ) : ICommand<bool>;
}