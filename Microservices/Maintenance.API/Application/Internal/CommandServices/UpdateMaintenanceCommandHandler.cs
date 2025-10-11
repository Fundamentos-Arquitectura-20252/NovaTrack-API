using MediatR;
using NovaTrack.Maintenance.Domain.Model.Commands;
using NovaTrack.Maintenance.Domain.Model.Aggregates;
using NovaTrack.Maintenance.Domain.Repositories;
using NovaTrack.Shared.Domain.Repositories;

namespace NovaTrack.Maintenance.Application.Internal.CommandServices
{
    public class UpdateMaintenanceCommandHandler : IRequestHandler<UpdateMaintenanceCommand, bool>
    {
        private readonly IMaintenanceRecordRepository _maintenanceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateMaintenanceCommandHandler(IMaintenanceRecordRepository maintenanceRepository, IUnitOfWork unitOfWork)
        {
            _maintenanceRepository = maintenanceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateMaintenanceCommand request, CancellationToken cancellationToken)
        {
            var maintenance = await _maintenanceRepository.FindByIdAsync(request.MaintenanceId);
            if (maintenance == null) return false;

            maintenance.UpdateDescription(request.Description);
            maintenance.UpdateCost(request.EstimatedCost);
            maintenance.RescheduleService(request.ScheduledDate, "Updated via command");
            maintenance.UpdateServiceProvider(request.ServiceProvider);

            if (!string.IsNullOrEmpty(request.Notes))
                maintenance.AddNotes(request.Notes);

            _maintenanceRepository.Update(maintenance);
            await _unitOfWork.CompleteAsync();

            return true;
        }
    }
}
