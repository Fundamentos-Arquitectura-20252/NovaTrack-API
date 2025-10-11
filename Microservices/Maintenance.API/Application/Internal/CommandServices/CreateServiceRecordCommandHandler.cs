using MediatR;
using NovaTrack.Maintenance.Domain.Model.Commands;
using NovaTrack.Maintenance.Domain.Model.Aggregates;
using NovaTrack.Maintenance.Domain.Repositories;
using NovaTrack.Shared.Domain.Repositories;

namespace NovaTrack.Maintenance.Application.Internal.CommandServices
{
    public class CreateServiceRecordCommandHandler : IRequestHandler<CreateServiceRecordCommand, int>
    {
        private readonly IServiceRecordRepository _serviceRecordRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateServiceRecordCommandHandler(IServiceRecordRepository serviceRecordRepository, IUnitOfWork unitOfWork)
        {
            _serviceRecordRepository = serviceRecordRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateServiceRecordCommand request, CancellationToken cancellationToken)
        {
            var serviceRecord = new ServiceRecord(
                request.VehicleId,
                request.ServiceType,
                request.Description,
                request.Cost,
                request.ServiceDate,
                request.MileageAtService,
                request.ServiceProvider,
                request.TechnicianName
            );

            if (!string.IsNullOrEmpty(request.PartsUsed))
                serviceRecord.AddPartsUsed(request.PartsUsed);

            if (!string.IsNullOrEmpty(request.Notes))
                serviceRecord.AddNotes(request.Notes);

            await _serviceRecordRepository.AddAsync(serviceRecord);
            await _unitOfWork.CompleteAsync();

            return serviceRecord.Id;
        }
    }
}
