using System.Collections.ObjectModel;
using StretchCeiling.Domain;

namespace StretchCeiling.Model
{
    public class Ceiling : ICeiling
    {
        private Component _cloth;
        private Component _profile;
        private ObservableCollection<Component> _components;
     
        public SchemeCeiling Scheme { get; set; }
        public PointCollection Points => Scheme.Points;

        public string Name { get; set; }
        public double Square { get; set; }
        public double Perimeter { get; set; }
        public double Price { get; set; }
        public ObservableCollection<Component> Components { get => _components; private set => _components = value; }

        public Ceiling()
        {
            Scheme = new SchemeCeiling();
            _components = new ObservableCollection<Component>();
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
            _components.Add(_cloth);
            _components.Add(_profile);
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
            foreach (var component in _components)
            {
                var multiply = component.Price * component.Count;
                componentsPrice += multiply;
            }

            return clothPrice + profilePrice + componentsPrice;
        }

        internal double GetPerimeter()
        {
            Perimeter = Scheme.GetPerimeter();
            _components[1].Count = Perimeter;
            return Perimeter;
        }

        internal double GetSquare()
        {
            Square = Scheme.GetSquare();
            _components[0].Count = Square;
            return Square;
        }

        internal void AddComponent(Component component)
        {
            _components.Add(component);
        }
    }
}
