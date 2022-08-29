
namespace StretchCeiling.Model
{
    public class Ceiling
    {
        public Ceiling()
        {
            Scheme = new SchemeCeiling();
            cloth = new()
            {
                Name = "Cloth",
                Price = 400,
                Measure = "m2"
            };
            profile = new()
            {
                Name = "Profile",
                Price = 100,
                Measure = "m"
            };
        }

        public SchemeCeiling Scheme { get; set; }
        public PointCollection Points => Scheme.Points;

        public double Square { get; set; }
        public double Perimeter { get; set; }
        public double Price { get; set; }
        private Component cloth;
        private Component profile;



        private double GetPrice()
        {
            double squ = Square * cloth.Price;
            double prm = Perimeter * profile.Price;
            return squ + prm;
        }

        internal void RefreshPrice()
        {
            Price = GetPrice();
        }
    }
}
