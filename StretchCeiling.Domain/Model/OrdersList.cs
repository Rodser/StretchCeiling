namespace StretchCeiling.Domain.Model
{
    public class OrdersList
    {
        public List<Order>? Orders { get; set; }

        public List<int> GetOrdersID()
        {
            List<int> ids = new();

            if (Orders is not null)
            {

                foreach (var order in Orders)
                {
                    ids.Add(order.Id);
                }
            }
            return ids;
        }
    }
}
