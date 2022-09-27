using StretchCeiling.Model;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace StretchCeiling.Service
{
    public class OrderService
    {
        private const string ORDER_DATA = "orderdata.json";
        private ObservableCollection<Order> _orders;

        public OrderService()
        {
            _orders = new ObservableCollection<Order>();
        }

        /// <summary>
        /// Получить коллекцию
        /// </summary>
        /// <returns></returns>
        public async Task<ObservableCollection<Order>> GetOrders()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            using var reader = new StreamReader($"{appData}/{ORDER_DATA}");
            var contents = await reader.ReadToEndAsync();
            _orders = JsonSerializer.Deserialize<ObservableCollection<Order>>(contents);
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
