using NovaTrack.IAM.Domain.Model.Aggregates;
using NovaTrack.IAM.Domain.Model.Commands;
using NovaTrack.IAM.Interfaces.REST.Resources;


// SignUpCommandFromResourceAssembler.cs
namespace NovaTrack.IAM.Interfaces.REST.Transform
{
    public static class SignUpCommandFromResourceAssembler
    {
        public static SignUpUserCommand ToCommandFromResource(SignUpResource resource)
        {
            return new SignUpUserCommand(
                resource.FirstName,
                resource.LastName,
                resource.Email,
                resource.Password,
                resource.Role
            );
        }
    }
}
