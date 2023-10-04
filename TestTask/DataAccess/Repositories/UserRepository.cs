using Microsoft.EntityFrameworkCore;
using TestTask.DataAccess.Database;
using TestTask.DataAccess.Enums;
using TestTask.DataAccess.Models;
using TestTask.DataAccess.Repositories.Interfaces;

namespace TestTask.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<User> GetUserWithLargestOrdersCount(CancellationToken cancellationToken = default)
        {
            return _applicationDbContext.Users.Include(u => u.Orders)
                .AsNoTracking().OrderByDescending(u => u.Orders.Count)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public Task<List<User>> GetUsersByStatus(UserStatus status,
                                                 CancellationToken cancellationToken = default)
        {
            return _applicationDbContext.Users.AsNoTracking()
                .Where(u => u.Status == status).ToListAsync(cancellationToken);
        }
    }
}
