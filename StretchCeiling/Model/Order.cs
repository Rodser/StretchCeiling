using System.Collections.ObjectModel;

namespace StretchCeiling.Model
{
    public class Order
    {
        public string Address { get; set; }
        public ObservableCollection<Ceiling> Ceilings { get; set; }
        public int CallNumber { get; set; }
        public DateTime DateTime { get; set; }
        public float Price { get; set; }
    }
}
