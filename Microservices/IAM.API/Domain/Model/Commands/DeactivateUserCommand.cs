using NovaTrack.Shared.Domain.Model;


namespace NovaTrack.IAM.Domain.Model.Commands
{
    public record DeactivateUserCommand(
        int UserId
    ) : ICommand<bool>;
}