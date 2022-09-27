namespace StretchCeiling.Domain
{
    public interface IOrder
    {
        string Address { get; set; }
        // List<ICeiling> Ceilings { get; set; }
        int CallNumber { get; set; }
        DateTime DateTime { get; set; }
        double Price { get; set; }
    }
}
