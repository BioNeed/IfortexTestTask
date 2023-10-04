using TestTask.Models;
using Microsoft.Extensions.Options;
using TestTask.Services.Interfaces;
using TestTask.DataAccess.Models;
using TestTask.DataAccess.Repositories.Interfaces;

namespace TestTask.Services
{
    public class OrderService : IOrderService
    {
        private readonly int _minQuantityForBigOrders;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository,
                            IOptionsSnapshot<SettingsModel> settings)
        {
            _orderRepository = orderRepository;
            _minQuantityForBigOrders = settings.Value.MinQuantityForBigOrders;
        }

        public Task<Order> GetOrder()
        {
            return _orderRepository.GetOrderWithHighestTotalPrice();
        }

        public Task<List<Order>> GetOrders()
        {
            return _orderRepository.GetOrdersWithManyItems(_minQuantityForBigOrders);
        }
    }
}
