using NovaTrack.Shared.Domain.Model;
namespace NovaTrack.Maintenance.Domain.Model.Commands
{
public record DeleteServiceRecordCommand(
int ServiceRecordId
) : ICommand<bool>;
}