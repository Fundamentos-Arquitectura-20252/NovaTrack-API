using NovaTrack.IAM.Domain.Model.Aggregates;
using NovaTrack.IAM.Domain.Model.Commands;
using NovaTrack.IAM.Interfaces.REST.Resources;



// SignInCommandFromResourceAssembler.cs
namespace NovaTrack.IAM.Interfaces.REST.Transform
{
    public static class SignInCommandFromResourceAssembler
    {
        public static SignInUserCommand ToCommandFromResource(SignInResource resource)
        {
            return new SignInUserCommand(
                resource.Email,
                resource.Password
            );
        }
    }
}

