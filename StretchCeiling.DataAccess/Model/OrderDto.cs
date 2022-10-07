namespace StretchCeiling.DataAccess.Model
{
    public class OrderDto
    {
        public string Address { get; set; }
        public int CallNumber { get; set; }
        public double Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime InstallationDate { get; set; }
        public List<CeilingDto> Ceilings { get; set; }
    }
}
