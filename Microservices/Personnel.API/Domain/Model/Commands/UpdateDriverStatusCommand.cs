using NovaTrack.Personnel.Domain.Model.Aggregates;
using NovaTrack.Shared.Domain.Model;
using NovaTrack.Personnel.Domain.Model.ValueObjects;

namespace NovaTrack.Personnel.Domain.Model.Commands
{
    public record UpdateDriverStatusCommand(
        int DriverId,
        DriverStatus Status
    ) : ICommand<bool>;
}
