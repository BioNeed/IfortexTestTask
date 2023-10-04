using TestTask.DataAccess.Models;

namespace TestTask.DataAccess.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersWithManyItems(int itemsMinCount, CancellationToken cancellationToken = default);

        Task<Order> GetOrderWithHighestTotalPrice(CancellationToken cancellationToken = default);
    }
}