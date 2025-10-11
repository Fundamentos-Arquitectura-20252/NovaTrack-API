using MediatR;
using NovaTrack.IAM.Domain.Model.Commands;
using NovaTrack.IAM.Domain.Model.Aggregates;
using NovaTrack.IAM.Domain.Repositories;
using NovaTrack.Shared.Domain.Repositories;


namespace NovaTrack.IAM.Application.Internal.CommandServices
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserProfileCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByIdAsync(request.UserId);
            if (user == null || !user.IsActive)
                return false;

            // Verificar si el nuevo email ya existe (excluyendo el usuario actual)
            if (user.Email != request.Email && await _userRepository.ExistsByEmailAsync(request.Email))
                throw new InvalidOperationException("Email already registered");

            user.UpdateProfile(request.FirstName, request.LastName, request.Email);
            _userRepository.Update(user);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
