using NovaTrack.Shared.Domain.Model;
using NovaTrack.IAM.Interfaces.REST.Resources;

// GetUserByIdQuery.cs
namespace NovaTrack.IAM.Domain.Model.Queries
{
    public record GetUserByIdQuery(int UserId) : IQuery<UserResource?>;
}