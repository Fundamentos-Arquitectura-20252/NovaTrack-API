using MediatR;
using NovaTrack.Maintenance.Domain.Model.Commands;
using NovaTrack.Maintenance.Domain.Model.Aggregates;
using NovaTrack.Maintenance.Domain.Repositories;
using NovaTrack.Shared.Domain.Repositories;

namespace NovaTrack.Maintenance.Application.Internal.CommandServices
{
    public class CancelMaintenanceCommandHandler : IRequestHandler<CancelMaintenanceCommand, bool>
    {
        private readonly IMaintenanceRecordRepository _maintenanceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CancelMaintenanceCommandHandler(IMaintenanceRecordRepository maintenanceRepository, IUnitOfWork unitOfWork)
        {
            _maintenanceRepository = maintenanceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CancelMaintenanceCommand request, CancellationToken cancellationToken)
        {
            var maintenance = await _maintenanceRepository.FindByIdAsync(request.MaintenanceId);
            if (maintenance == null) return false;

            maintenance.CancelMaintenance(request.Reason);
            _maintenanceRepository.Update(maintenance);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
