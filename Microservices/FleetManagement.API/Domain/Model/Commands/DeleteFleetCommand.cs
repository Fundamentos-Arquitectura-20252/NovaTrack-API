using NovaTrack.Shared.Domain.Model;

namespace NovaTrack.FleetManagement.Domain.Model.Commands
{
    public record DeleteFleetCommand(
        int FleetId
    ) : ICommand<bool>;
}
