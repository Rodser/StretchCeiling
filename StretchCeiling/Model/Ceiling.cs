using StretchCeiling.Domain;
using StretchCeiling.Domain.Model;

namespace StretchCeiling.Model
{
    public class Ceiling : ICeiling
    {
        private Equipment _cloth;
        private Equipment _profile;

        public IScheme Scheme { get; set; }
        public List<IVertex> Points => Scheme.Points;        
        public List<IEquipment> Equipments { get; set; }
        public string Name { get; set; }
        public double Square { get; set; }
        public double Perimeter { get; set; }
        public double Price { get; set; }

        public Ceiling()
        {
            Scheme = new Scheme();
            Equipments = new List<IEquipment>();
            _cloth = new()
            {
                Name = "Cloth",
                Price = 400,
                Measure = "m2"
            };
            _profile = new()
            {
                Name = "Profile",
                Price = 100,
                Measure = "m"
            };
            Equipments.Add(_cloth);
            Equipments.Add(_profile);
        }

        internal void RefreshPrice()
        {
            Price = GetPrice();
        }

        private double GetPrice()
        {
            double clothPrice = Square * _cloth.Price;
            double profilePrice = Perimeter * _profile.Price;

            double componentsPrice = 0;
            foreach (var component in Equipments)
            {
                var multiply = component.Price * component.Count;
                componentsPrice += multiply;
            }

            return clothPrice + profilePrice + componentsPrice;
        }

        internal double GetPerimeter()
        {
            Perimeter = Scheme.GetPerimeter();
            Equipments[1].Count = Perimeter;
            return Perimeter;
        }

        internal double GetSquare()
        {
            Square = Scheme.GetSquare();
            Equipments[0].Count = Square;
            return Square;
        }

        internal void AddComponent(Equipment component)
        {
            Equipments.Add(component);
        }
    }
}
