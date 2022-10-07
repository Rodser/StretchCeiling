namespace StretchCeiling.Model
{
    public class Order 
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public List<Ceiling> Ceilings { get; set; }
        public int CallNumber { get; set; }
        public double Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime InstallationDate { get; set; }
    }
}
