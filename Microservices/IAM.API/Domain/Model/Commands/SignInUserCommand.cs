using NovaTrack.Shared.Domain.Model;

// SignInUserCommand.cs
namespace NovaTrack.IAM.Domain.Model.Commands
{
    public record SignInUserCommand(
        string Email,
        string Password
    ) : ICommand<int>;
}