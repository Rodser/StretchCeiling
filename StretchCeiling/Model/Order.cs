namespace StretchCeiling.Model
{
    public class Order
    {
        private DateTime dateTime;

        public string Address { get; set; } = "Samara";
        public List<Ceiling> Cillings { get; set; }
        public int CallNumber { get; set; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public float Price { get; set; }
    }
}
