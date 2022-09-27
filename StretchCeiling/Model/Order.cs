using StretchCeiling.Domain;

namespace StretchCeiling.Model
{
    public class Order : IOrder
    {
        public string Address { get; set; } = "Samara";
        public List<ICeiling> Cillings { get; set; }
        public int CallNumber { get; set; }
        public float Price { get; set; }
        public DateTime DateTime { get; set; }
    }
}
