using NovaTrack.IAM.Domain.Model.Aggregates;
using NovaTrack.Shared.Domain.Repositories;

namespace NovaTrack.IAM.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> FindByEmailAsync(string email);
        Task<bool> ExistsByEmailAsync(string email);
        Task<IEnumerable<User>> FindActiveUsersAsync();
        Task<User?> FindByEmailAndPasswordAsync(string email, string passwordHash);
    }
}