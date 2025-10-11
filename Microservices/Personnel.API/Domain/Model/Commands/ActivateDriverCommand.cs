using NovaTrack.Shared.Domain.Model;

namespace NovaTrack.Personnel.Domain.Model.Commands
{
    public record ActivateDriverCommand(
        int DriverId
    ) : ICommand<bool>;
}
