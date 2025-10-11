using NovaTrack.FleetManagement.Domain.Model.Aggregates;
using NovaTrack.FleetManagement.Domain.Model.ValueObjects;
using NovaTrack.Shared.Domain.Repositories;

// IFleetRepository.cs
namespace NovaTrack.FleetManagement.Domain.Repositories
{
    public interface IFleetRepository : IBaseRepository<Fleet>
    {
        Task<bool> ExistsByCodeAsync(string code);
        Task<Fleet?> FindByCodeAsync(string code);
        Task<IEnumerable<Fleet>> FindByTypeAsync(FleetType type);
        Task<IEnumerable<Fleet>> FindActiveFleetAsync();
        Task<Fleet?> FindByIdWithVehiclesAsync(int id);
    }
}
