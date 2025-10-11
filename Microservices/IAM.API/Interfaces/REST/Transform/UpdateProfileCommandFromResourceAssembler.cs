using NovaTrack.IAM.Domain.Model.Aggregates;
using NovaTrack.IAM.Domain.Model.Commands;
using NovaTrack.IAM.Interfaces.REST.Resources;


// UpdateProfileCommandFromResourceAssembler.cs
namespace NovaTrack.IAM.Interfaces.REST.Transform
{
    public static class UpdateProfileCommandFromResourceAssembler
    {
        public static UpdateUserProfileCommand ToCommandFromResource(int userId, UpdateProfileResource resource)
        {
            return new UpdateUserProfileCommand(
                userId,
                resource.FirstName,
                resource.LastName,
                resource.Email
            );
        }
    }
}
