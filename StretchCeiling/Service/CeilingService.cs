using StretchCeiling.Domain.Model;
using StretchCeiling.Helper;
using StretchCeiling.Model;

namespace StretchCeiling.Service
{
    public class CeilingService
    {
        private readonly List<Ceiling> _ceilings;

        public double TotalPrice { get => GetPrice(); }

        public CeilingService(Order order)
        {            
            _ceilings = ModelConverter<Ceiling, ICeiling>.ToModel(order.Ceilings);
            if (_ceilings is null)
            {
                _ceilings = new List<Ceiling>();
            }
        }

        /// <summary>
        /// Получить коллекцию потолков
        /// </summary>
        /// <returns></returns>
        public List<ICeiling> GetCeilings()
        {            
            return ModelConverter<Ceiling, ICeiling>.FromModel(_ceilings);
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
