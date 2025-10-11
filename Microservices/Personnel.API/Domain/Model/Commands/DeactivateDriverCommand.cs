using NovaTrack.Shared.Domain.Model;

namespace NovaTrack.Personnel.Domain.Model.Commands
{
    public record DeactivateDriverCommand(
        int DriverId
    ) : ICommand<bool>;
}
