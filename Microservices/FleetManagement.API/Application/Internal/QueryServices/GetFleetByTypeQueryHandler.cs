using MediatR;
using NovaTrack.FleetManagement.Domain.Model.Queries;
using NovaTrack.FleetManagement.Domain.Repositories;
using NovaTrack.FleetManagement.Interfaces.REST.Resources;
using NovaTrack.FleetManagement.Interfaces.REST.Transform;
using NovaTrack.FleetManagement.Domain.Model.ValueObjects;

// GetFleetByTypeQueryHandler.cs
namespace NovaTrack.FleetManagement.Application.Internal.QueryServices
{
    public class GetFleetByTypeQueryHandler : IRequestHandler<GetFleetByTypeQuery, IEnumerable<FleetResource>>
    {
        private readonly IFleetRepository _fleetRepository;

        public GetFleetByTypeQueryHandler(IFleetRepository fleetRepository)
        {
            _fleetRepository = fleetRepository;
        }

        public async Task<IEnumerable<FleetResource>> Handle(GetFleetByTypeQuery request, CancellationToken cancellationToken)
        {
            if (!Enum.TryParse<FleetType>(request.Type, true, out var fleetType))
                return Enumerable.Empty<FleetResource>();

            var fleets = await _fleetRepository.FindByTypeAsync(fleetType);
            return fleets.Select(FleetResourceFromEntityAssembler.ToResourceFromEntity);
        }
    }
}
