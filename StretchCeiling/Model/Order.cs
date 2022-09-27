using StretchCeiling.Domain;
using System.Collections.ObjectModel;

namespace StretchCeiling.Model
{
    public class Order : IOrder
    {
        public string Address { get; set; } = "Samara";
        public List<Ceiling> Ceilings { get; set; }

        public int CallNumber { get; set; }
        public double Price { get; set; }
        public DateTime DateTime { get; set; }

        //public List<Ceiling> GetCeilings()
        //{
        //    var ceilings = new List<Ceiling>();
        //    if (Ceilings is not null)
        //    {
        //        foreach (var ceiling in Ceilings)
        //        {
        //            ceilings.Add(ceiling as Ceiling);
        //        }
        //    }
        //    return ceilings;
        
    }
}
