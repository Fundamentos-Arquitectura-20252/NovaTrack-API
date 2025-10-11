using MediatR;
using NovaTrack.IAM.Domain.Model.Queries;
using NovaTrack.IAM.Domain.Repositories;
using NovaTrack.IAM.Interfaces.REST.Resources;
using NovaTrack.IAM.Interfaces.REST.Transform;



// GetUserByEmailQueryHandler.cs
namespace NovaTrack.IAM.Application.Internal.QueryServices
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserResource?>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResource?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByEmailAsync(request.Email);
            return user != null ? UserResourceFromEntityAssembler.ToResourceFromEntity(user) : null;
        }
    }
}