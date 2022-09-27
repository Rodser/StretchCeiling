using StretchCeiling.Model;
using System.Collections.ObjectModel;

namespace StretchCeiling.Service
{
    public class CeilingService
    {
        private readonly ObservableCollection<Ceiling> _ceilings;

        public double TotalPrice { get => GetPrice(); }

        public CeilingService(Order order)
        {
            var ceilings = order.Ceilings;
            if(ceilings is null)
            {
                ceilings = new ObservableCollection<Ceiling>();
            }
            _ceilings = ceilings;
        }

        /// <summary>
        /// Получить коллекцию потолков
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Ceiling> GetCeilings()
        {
            return _ceilings;
        }

        /// <summary>
        /// Дообавляет новый потолок
        /// </summary>
        /// <param name="ceiling"></param>
        internal void AddCeiling(Ceiling ceiling)
        {
            _ceilings.Add(ceiling);
            GetPrice();
        }

        /// <summary>
        /// Удаляет пустой слот
        /// </summary>
        internal void ClearEmptyCeilings(Ceiling ceiling)
        {
            _ceilings.Remove(ceiling);
        }

        private double GetPrice()
        {
            double price = 0;
            foreach (var ceiling in _ceilings)
            {
                price += ceiling.Price;
            }
            return price;
        }
    }
}
