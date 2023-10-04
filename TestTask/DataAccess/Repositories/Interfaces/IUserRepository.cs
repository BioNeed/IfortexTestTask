using TestTask.DataAccess.Enums;
using TestTask.DataAccess.Models;

namespace TestTask.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersByStatus(UserStatus status, CancellationToken cancellationToken = default);

        Task<User> GetUserWithLargestOrdersCount(CancellationToken cancellationToken = default);
    }
}