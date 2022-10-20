namespace StretchCeiling.Model
{
    public class Order 
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public List<Ceiling> Ceilings { get; set; }
        public int CallNumber { get; set; }
        public double Price => GetPrice();
        public DateTime CreationDate { get; set; }
        public DateTime InstallationDate { get; set; }


        /// <summary>
        /// Получить коллекцию потолков
        /// </summary>
        /// <returns></returns>
        public List<Ceiling> GetCeilings()
        {
            return Ceilings;
        }

        /// <summary>
        /// Дообавляет новый потолок
        /// </summary>
        /// <param name="ceiling"></param>
        internal void AddCeiling(Ceiling ceiling)
        {
            Ceilings.Add(ceiling);
        }

        /// <summary>
        /// Удаляет
        /// </summary>
        internal void RemoveCeiling(Ceiling ceiling)
        {
            Ceilings.Remove(ceiling);
        }

        private double GetPrice()
        {
            double price = 0;
            foreach (var ceiling in Ceilings)
            {
                price += ceiling.Price;
            }
            return price;
        }
    }
}
