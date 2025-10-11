using MediatR;
using NovaTrack.IAM.Domain.Model.Queries;
using NovaTrack.IAM.Domain.Repositories;
using NovaTrack.IAM.Interfaces.REST.Resources;
using NovaTrack.IAM.Interfaces.REST.Transform;

// GetUserByIdQueryHandler.cs
namespace NovaTrack.IAM.Application.Internal.QueryServices
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResource?>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResource?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByIdAsync(request.UserId);
            return user != null ? UserResourceFromEntityAssembler.ToResourceFromEntity(user) : null;
        }
    }
}