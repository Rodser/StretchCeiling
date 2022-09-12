﻿using StretchCeiling.Model;
using System.Collections.ObjectModel;

namespace StretchCeiling.Service
{
    public class CeilingService
    {
        private readonly ObservableCollection<Ceiling> s_ceilings;

        public double TotalPrice { get => GetPrice(); }

        public CeilingService()
        {
            s_ceilings = new ObservableCollection<Ceiling>();
        }

        /// <summary>
        /// Получить коллекцию потолков
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Ceiling> GetCeilings()
        {
            return s_ceilings;
        }

        /// <summary>
        /// Дообавляет новый потолок
        /// </summary>
        /// <param name="ceiling"></param>
        internal void AddCeiling(Ceiling ceiling)
        {
            s_ceilings.Add(ceiling);
            GetPrice();
        }

        /// <summary>
        /// Удаляет пустой слот
        /// </summary>
        internal void ClearEmptyCeilings(Ceiling ceiling)
        {
            s_ceilings.Remove(ceiling);
        }

        private double GetPrice()
        {
            double price = 0;
            foreach (var ceiling in s_ceilings)
            {
                price += ceiling.Price;
            }
            return price;
        }
    }
}
