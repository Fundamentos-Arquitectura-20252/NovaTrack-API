using MediatR;
using NovaTrack.IAM.Domain.Model.Commands;
using NovaTrack.IAM.Domain.Model.Aggregates;
using NovaTrack.IAM.Domain.Repositories;
using NovaTrack.Shared.Domain.Repositories;

namespace NovaTrack.IAM.Application.Internal.CommandServices
{
    public class SignInUserCommandHandler : IRequestHandler<SignInUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public SignInUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByEmailAsync(request.Email);
            
            if (user == null || !user.IsActive)
                throw new UnauthorizedAccessException("Invalid credentials");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials");

            return user.Id;
        }
    }
}
