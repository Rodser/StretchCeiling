namespace StretchCeiling.Domain.Model
{
    public interface ICeiling
    {     
        List<IEquipment> Equipments { get; set; }
        IScheme Scheme { get; set; }
        string Name { get; set; }
        double Square { get; set; }
        double Perimeter { get; set; }
        double Price { get; set; }
    }
}
