using StretchCeiling.Domain.Model;

namespace StretchCeiling.DataAccess.Model
{
    public class Ceiling : ICeiling
    {
        public IScheme Scheme { get; set; }
        public List<IEquipment> Equipments { get; set; }
        public string Name { get; set; }
        public double Square { get; set; }
        public double Perimeter { get; set; }
        public double Price { get; set; }

    }
}
