using NovaTrack.IAM.Domain.Model.Aggregates;
using NovaTrack.IAM.Domain.Model.Commands;
using NovaTrack.IAM.Interfaces.REST.Resources;


// ChangePasswordCommandFromResourceAssembler.cs
namespace NovaTrack.IAM.Interfaces.REST.Transform
{
    public static class ChangePasswordCommandFromResourceAssembler
    {
        public static ChangeUserPasswordCommand ToCommandFromResource(int userId, ChangePasswordResource resource)
        {
            return new ChangeUserPasswordCommand(
                userId,
                resource.CurrentPassword,
                resource.NewPassword
            );
        }
    }
}