using StretchCeiling.Domain.Model;

namespace StretchCeiling.DataAccess.Model
{
    public class Equipment : IEquipment
    {
        public string Name { get; set; }
        public string Measure { get; set; }
        public double Price { get; set; }
        public double Count { get; set; }
    }
}
