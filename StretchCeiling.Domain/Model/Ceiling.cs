namespace StretchCeiling.Domain.Model
{
    public class Ceiling
    {
        public List<Equipment>? Equipments { get; set; }
        public Scheme? Scheme { get; set; }
        public string? Name { get; set; }
        public double Square { get; set; }
        public double Perimeter { get; set; }
        public double Price { get; set; }
    }
}