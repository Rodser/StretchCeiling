using StretchCeiling.Domain.Model;

namespace StretchCeiling.DataAccess.Model
{
    public class Scheme : IScheme
    {
        public List<ISide> Sides { get; set; }
        public List<IVertex> Points { get; set; }

        public double GetPerimeter()
        {
            throw new NotImplementedException();
        }

        public double GetSquare()
        {
            throw new NotImplementedException();
        }
    }
}
