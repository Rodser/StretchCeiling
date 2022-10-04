using StretchCeiling.Domain.Model;

namespace StretchCeiling.DataAccess.Model
{
    public class Side : ISide
    {
        public IVertex StartPoint { get; set; }
        public IVertex EndPoint { get; set; }
        public string StartName { get; set; }
        public string EndName { get; set; }
        public string Description { get; set; }
        public double Distance { get; set; }
        public IAngle Angle { get; set; }

    }
}
