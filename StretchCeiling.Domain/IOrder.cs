namespace StretchCeiling.Domain
{
    public interface IOrder
    {
        string Address { get; set; }
        List<ICeiling> Cillings { get; set; }
        int CallNumber { get; set; }
        DateTime DateTime { get; set; }
        float Price { get; set; }
    }
}
