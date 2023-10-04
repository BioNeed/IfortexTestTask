using Microsoft.EntityFrameworkCore;
using TestTask.DataAccess.Database;
using TestTask.DataAccess.Models;
using TestTask.DataAccess.Repositories.Interfaces;

namespace TestTask.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrderRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<Order> GetOrderWithHighestTotalPrice(CancellationToken cancellationToken = default)
        {
            return _applicationDbContext.Orders.AsNoTracking()
                .OrderByDescending(o => o.Price * o.Quantity).FirstOrDefaultAsync(cancellationToken);
        }

        public Task<List<Order>> GetOrdersWithManyItems(int itemsMinCount,
                                                        CancellationToken cancellationToken = default)
        {
            return _applicationDbContext.Orders.AsNoTracking()
                .Where(o => o.Quantity >= itemsMinCount).ToListAsync(cancellationToken);
        }
    }
}
