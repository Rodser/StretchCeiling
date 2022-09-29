using StretchCeiling.Domain;

namespace StretchCeiling.Model
{
    public class Equipment : IEquipment
    {
        public string Name { get; set; }
        public string Measure { get; set; }
        public double Price { get; set; }
        public double Count { get; set; }
    }
}
