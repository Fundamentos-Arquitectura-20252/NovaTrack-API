using NovaTrack.Shared.Domain.Model;
using NovaTrack.IAM.Interfaces.REST.Resources;

namespace NovaTrack.IAM.Domain.Model.Queries
{
    public record GetAllUsersQuery() : IQuery<IEnumerable<UserResource>>;
}