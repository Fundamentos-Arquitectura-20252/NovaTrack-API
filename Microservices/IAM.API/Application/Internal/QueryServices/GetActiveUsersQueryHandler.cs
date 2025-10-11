using MediatR;
using NovaTrack.IAM.Domain.Model.Queries;
using NovaTrack.IAM.Domain.Repositories;
using NovaTrack.IAM.Interfaces.REST.Resources;
using NovaTrack.IAM.Interfaces.REST.Transform;


// GetActiveUsersQueryHandler.cs
namespace NovaTrack.IAM.Application.Internal.QueryServices
{
    public class GetActiveUsersQueryHandler : IRequestHandler<GetActiveUsersQuery, IEnumerable<UserResource>>
    {
        private readonly IUserRepository _userRepository;

        public GetActiveUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserResource>> Handle(GetActiveUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.FindActiveUsersAsync();
            return users.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
        }
    }
}