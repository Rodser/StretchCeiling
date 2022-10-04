using StretchCeiling.Domain.Model;

namespace StretchCeiling.DataAccess.Model
{
    public class Angle : IAngle
    {
        public double Radian { get; set; }
        public double Degrees { get; set; }
    }
}
