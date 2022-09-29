namespace StretchCeiling.Domain
{
    public interface IEquipment
    {
        string Name { get; set; }
        string Measure { get; set; }
        double Price { get; set; }
        double Count { get; set; }
    }
}