
namespace StretchCeiling.Model
{
    public class Ceiling
    {
        public Ceiling()
        {
            Scheme = new SchemeCeiling();
        }

        public SchemeCeiling Scheme { get; set; }

        public int Square { get; set; }
        public int Perimeter { get; set; }
        public int Price { get; set; }
    }
}
