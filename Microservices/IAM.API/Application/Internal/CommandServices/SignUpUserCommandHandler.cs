using MediatR;
using NovaTrack.IAM.Domain.Model.Commands;
using NovaTrack.IAM.Domain.Model.Aggregates;
using NovaTrack.IAM.Domain.Repositories;
using NovaTrack.Shared.Domain.Repositories;

namespace NovaTrack.IAM.Application.Internal.CommandServices
{
    public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SignUpUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
        {
            // Verificar si el email ya existe
            if (await _userRepository.ExistsByEmailAsync(request.Email))
                throw new InvalidOperationException("Email already registered");

            // Hash de la contraseña
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // Crear usuario
            var user = new User(
                request.FirstName,
                request.LastName,
                request.Email,
                passwordHash,
                request.Role
            );

            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            return user.Id;
        }
    }
}