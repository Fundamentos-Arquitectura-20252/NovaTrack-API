using MediatR;
using NovaTrack.FleetManagement.Domain.Model.Queries;
using NovaTrack.FleetManagement.Domain.Repositories;
using NovaTrack.FleetManagement.Interfaces.REST.Resources;
using NovaTrack.FleetManagement.Interfaces.REST.Transform;

// GetAllFleetsQueryHandler.cs
namespace NovaTrack.FleetManagement.Application.Internal.QueryServices
{
    public class GetAllFleetsQueryHandler : IRequestHandler<GetAllFleetsQuery, IEnumerable<FleetResource>>
    {
        private readonly IFleetRepository _fleetRepository;

        public GetAllFleetsQueryHandler(IFleetRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;
        }

        public async Task<IEnumerable<FleetResource>> Handle(GetAllFleetsQuery request, CancellationToken cancellationToken)
        {
            var fleets = await _fleetRepository.ListAsync();
            return fleets.Select(FleetResourceFromEntityAssembler.ToResourceFromEntity);
        }
    }
}
