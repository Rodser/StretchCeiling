namespace StretchCeiling.DataAccess.Model
{
    public class CeilingDto
    {
        public SchemeDto Scheme { get; set; }
        public List<EquipmentDto> Equipments { get; set; }
        public string Name { get; set; }
        public double Square { get; set; }
        public double Perimeter { get; set; }
        public double Price { get; set; }
    }
}
