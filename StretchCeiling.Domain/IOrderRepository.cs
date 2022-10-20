using StretchCeiling.Domain.Model;

namespace StretchCeiling.Domain
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Получить коллекцию
        /// </summary>
        /// <returns></returns>
        Task<OrdersList> GetOrders();

        /// <summary>
        /// Дообавляет новый
        /// </summary>
        /// <param name="order"></param>
        Task AddOrder(Order order);

        /// <summary>
        /// Удаляет
        /// </summary>
        Task DeleteOrder(int orderId);
    }
}
