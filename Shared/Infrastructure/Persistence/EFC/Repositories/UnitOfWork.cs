
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NovaTrack.Shared.Domain.Repositories;
using NovaTrack.IAM.Domain.Model.Aggregates;
using NovaTrack.FleetManagement.Domain.Model.Aggregates;
using NovaTrack.Personnel.Domain.Model.Aggregates;
using NovaTrack.Maintenance.Domain.Model.Aggregates;

namespace NovaTrack.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}