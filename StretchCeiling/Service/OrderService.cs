using StretchCeiling.Model;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace StretchCeiling.Service
{
    public class OrderService
    {
        private const string ORDER_DATA = "orderdata.json";
        private List<Order> _orders;

        public OrderService()
        {
            _orders = new List<Order>();
        }

        /// <summary>
        /// Получить коллекцию
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetOrders()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            using var reader = new StreamReader($"{appData}/{ORDER_DATA}");
            var contents = await reader.ReadToEndAsync();
            _orders = JsonSerializer.Deserialize<List<Order>>(contents);
            return _orders;
        }

        /// <summary>
        /// Дообавляет новый
        /// </summary>
        /// <param name="order"></param>
        internal async Task AddOrder(Order order)
        {
            _orders.Add(order);
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            using var writer = new StreamWriter($"{ appData }/{ ORDER_DATA}");
            var contents = JsonSerializer.Serialize(_orders);
            await writer.WriteAsync(contents);
        }

        /// <summary>
        /// Удаляет
        /// </summary>
        /// <param name="order"></param>
        internal async Task DeleteOrder(Order order)
        {
            _orders.Remove(order);
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            using var writer = new StreamWriter($"{appData}/{ORDER_DATA}");
            var contents = JsonSerializer.Serialize(_orders);
            await writer.WriteAsync(contents);
        }
    }
}
