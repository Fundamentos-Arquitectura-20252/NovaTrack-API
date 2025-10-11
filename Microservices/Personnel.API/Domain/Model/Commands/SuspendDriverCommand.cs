using NovaTrack.Shared.Domain.Model;

namespace NovaTrack.Personnel.Domain.Model.Commands
{
    public record SuspendDriverCommand(
        int DriverId,
        string Reason
    ) : ICommand<bool>;
}
