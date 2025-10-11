using NovaTrack.Shared.Domain.Model;
using NovaTrack.FleetManagement.Domain.Model.ValueObjects;

namespace NovaTrack.FleetManagement.Domain.Model.Commands
{
    public record UpdateFleetCommand(
        int FleetId,
        string Name,
        string Description,
        FleetType Type,
        bool IsActive
    ) : ICommand<bool>;
}
