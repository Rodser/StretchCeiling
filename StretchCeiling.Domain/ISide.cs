using StretchCeiling.Domain.Model;

namespace StretchCeiling.Domain
{
    public interface ISide
    {
        IVertex StartPoint { get; set; }
        IVertex EndPoint { get; set; }
        string StartName { get; set; }
        string EndName { get; set; }
        string Description { get; set; }
        double Distance { get; set; }
        IAngle Angle { get; set; }
    }
}