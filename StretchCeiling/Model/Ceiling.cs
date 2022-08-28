
namespace StretchCeiling.Model
{
    public class Ceiling
    {
        public Ceiling()
        {
            Scheme = new SchemeCeiling();
        }

        public SchemeCeiling Scheme { get; set; }
        public PointCollection Points => Scheme.Points;

        public int Square { get; set; }
        public double Perimeter { get; set; }
        public int Price { get; set; }
    }
}
