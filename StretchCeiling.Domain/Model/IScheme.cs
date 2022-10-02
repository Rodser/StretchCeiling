namespace StretchCeiling.Domain.Model
{
    public interface IScheme
    {
        List<IVertex> Points { get; set; }
        List<ISide> Sides { get; set; }

        double GetPerimeter();
        double GetSquare();
    }
}
