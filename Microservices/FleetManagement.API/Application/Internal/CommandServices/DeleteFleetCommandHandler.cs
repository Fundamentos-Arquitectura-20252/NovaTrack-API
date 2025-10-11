using MediatR;
using NovaTrack.FleetManagement.Domain.Model.Commands;
using NovaTrack.FleetManagement.Domain.Repositories;
using NovaTrack.Shared.Domain.Repositories;

namespace NovaTrack.FleetManagement.Application.Internal.CommandServices
{
    public class DeleteFleetCommandHandler : IRequestHandler<DeleteFleetCommand, bool>
    {
        private readonly IFleetRepository _fleetRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFleetCommandHandler(IFleetRepository fleetRepository, IUnitOfWork unitOfWork)
        {
            _fleetRepository = fleetRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteFleetCommand request, CancellationToken cancellationToken)
        {
            var fleet = await _fleetRepository.FindByIdWithVehiclesAsync(request.FleetId);
            if (fleet == null) return false;

            fleet.Deactivate();
            _fleetRepository.Remove(fleet);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
