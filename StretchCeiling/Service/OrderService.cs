using StretchCeiling.Model;
using System.Collections.ObjectModel;

namespace StretchCeiling.Service
{
    public class OrderService
    {
        private readonly ObservableCollection<Order> _orders;

        public OrderService()
        {
            _orders = new ObservableCollection<Order>();
        }

        /// <summary>
        /// Получить коллекцию
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Order> GetOrders()
        {
            return _orders;
        }

        /// <summary>
        /// Дообавляет новый
        /// </summary>
        /// <param name="order"></param>
        internal void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        /// <summary>
        /// Удаляет пустой слот
        /// </summary>
        internal void ClearEmptyOrder(Order order)
        {
            _orders.Remove(order);
        }
    }
}
