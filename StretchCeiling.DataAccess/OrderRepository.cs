using Newtonsoft.Json;
using StretchCeiling.Domain;
using StretchCeiling.Domain.Model;

namespace StretchCeiling.DataAccess
{
    public class OrderRepository : IOrderRepository
    {
        private const string ORDER_DATA = "orders.json";
        private static int _orderID;

        private OrdersList _ordersList;
        private List<int> _ordersIds;

        public OrderRepository()
        {
            _ordersList = new();
            _ordersIds = new List<int>();
        }

        public async Task AddOrder(Order order)
        {
            _ordersList.Orders ??= new();

            if ( !_ordersIds.Contains(order.Id) )
            {
            order.Id = ++_orderID;
            _ordersList.Orders.Add(order);
            }

            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            using var writer = new StreamWriter($"{appData}\\{ORDER_DATA}");
            var contents = JsonConvert.SerializeObject(_ordersList);
            await writer.WriteAsync(contents);
        }

        public async Task<OrdersList> GetOrders()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            using var reader = new StreamReader($"{appData}\\{ORDER_DATA}");
            var contents = await reader.ReadToEndAsync();
            _ordersList = JsonConvert.DeserializeObject<OrdersList>(contents) ?? new();
            _ordersIds = _ordersList.GetOrdersID();
            return _ordersList;
        }

        public async Task DeleteOrder(int orderId)
        {
            if (_ordersList.Orders is null)
            { 
                return; 
            }

            _ordersList.Orders.Remove(_ordersList.Orders[orderId]);
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            using var writer = new StreamWriter($"{appData}/{ORDER_DATA}");
            var contents = JsonConvert.SerializeObject(_ordersList);
            await writer.WriteAsync(contents);
        }
    }
}
