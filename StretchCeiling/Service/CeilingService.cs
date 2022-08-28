using StretchCeiling.Model;
using System.Collections.ObjectModel;

namespace StretchCeiling.Service
{
    public class CeilingService
    {
        private ObservableCollection<Ceiling> s_ceilings;

        public CeilingService()
        {
            s_ceilings = new ObservableCollection<Ceiling>();
        }

        public ObservableCollection<Ceiling> GetCeilings()
        {
            return s_ceilings;
        }
    }
}
