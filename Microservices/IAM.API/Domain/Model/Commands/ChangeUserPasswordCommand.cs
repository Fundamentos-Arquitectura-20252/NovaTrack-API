using NovaTrack.Shared.Domain.Model;


namespace NovaTrack.IAM.Domain.Model.Commands
{
    public record ChangeUserPasswordCommand(
        int UserId,
        string CurrentPassword,
        string NewPassword
    ) : ICommand<bool>;
}