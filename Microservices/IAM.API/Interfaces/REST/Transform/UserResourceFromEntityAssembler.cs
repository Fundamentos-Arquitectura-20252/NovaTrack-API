using NovaTrack.IAM.Domain.Model.Aggregates;
using NovaTrack.IAM.Domain.Model.Commands;
using NovaTrack.IAM.Interfaces.REST.Resources;

// UserResourceFromEntityAssembler.cs
namespace NovaTrack.IAM.Interfaces.REST.Transform
{
    public static class UserResourceFromEntityAssembler
    {
        public static UserResource ToResourceFromEntity(User entity)
        {
            return new UserResource(
                entity.Id,
                entity.FirstName,
                entity.LastName,
                entity.Email,
                entity.Role,
                entity.IsActive,
                entity.CreatedAt,
                entity.UpdatedAt
            );
        }
    }
}