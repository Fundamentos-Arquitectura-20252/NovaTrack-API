using NovaTrack.Shared.Domain.Model;
using NovaTrack.FleetManagement.Domain.Model.ValueObjects;

namespace NovaTrack.FleetManagement.Domain.Model.Commands
{
    public record CreateFleetCommand(
        string Code,
        string Name,
        string Description,
        FleetType Type
    ) : ICommand<int>;
}
