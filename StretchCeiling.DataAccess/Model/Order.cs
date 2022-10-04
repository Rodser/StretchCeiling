using StretchCeiling.Domain.Model;

namespace StretchCeiling.DataAccess.Model
{
    public class Order : IOrder
    {
        public string Address { get; set; }
        public List<ICeiling> Ceilings { get; set; }
        public int CallNumber { get; set; }
        public double Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime InstallationDate { get; set; }

    }
}
