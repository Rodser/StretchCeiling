using StretchCeiling.Domain.Model;

namespace StretchCeiling.Domain
{
    public interface IScheme
    {
        List<IVertex> Points { get; set; }
        List<ISide> Sides { get; set; }

        double GetPerimeter();
        double GetSquare();
    }
}
