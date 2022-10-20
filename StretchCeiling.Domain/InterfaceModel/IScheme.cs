namespace StretchCeiling.Domain.InterfaceModel
{
    public interface IScheme
    {
        List<IVertex> Points { get; set; }
        List<ISide> Sides { get; set; }
    }
}
