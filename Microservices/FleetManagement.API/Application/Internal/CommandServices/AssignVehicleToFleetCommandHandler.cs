using MediatR;
using NovaTrack.FleetManagement.Domain.Model.Commands;
using NovaTrack.FleetManagement.Domain.Repositories;
using NovaTrack.Shared.Domain.Repositories;

namespace NovaTrack.FleetManagement.Application.Internal.CommandServices
{
    public class AssignVehicleToFleetCommandHandler : IRequestHandler<AssignVehicleToFleetCommand, bool>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IFleetRepository _fleetRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AssignVehicleToFleetCommandHandler(IVehicleRepository vehicleRepository, IFleetRepository fleetRepository, IUnitOfWork unitOfWork)
        {
            _vehicleRepository = vehicleRepository;
            _fleetRepository = fleetRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AssignVehicleToFleetCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.FindByIdAsync(request.VehicleId);
            if (vehicle == null) return false;

            var fleet = await _fleetRepository.FindByIdAsync(request.FleetId);
            if (fleet == null || !fleet.IsActive)
                throw new InvalidOperationException("Fleet not found or inactive");

            vehicle.AssignToFleet(request.FleetId);
            _vehicleRepository.Update(vehicle);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
