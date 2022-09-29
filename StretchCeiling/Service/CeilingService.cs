using StretchCeiling.Domain;
using StretchCeiling.Model;
using System.Collections.ObjectModel;

namespace StretchCeiling.Service
{
    public class CeilingService
    {
        private readonly List<ICeiling> _ceilings;

        public double TotalPrice { get => GetPrice(); }

        public CeilingService(Order order)
        {            
            _ceilings = order.Ceilings;
            if (_ceilings is null)
            {
                _ceilings = new List<ICeiling>();
            }
        }

        /// <summary>
        /// Получить коллекцию потолков
        /// </summary>
        /// <returns></returns>
        public List<ICeiling> GetCeilings()
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
