namespace StretchCeiling.Domain.Model
{
    public class Side
    {
        public Vertex? StartPoint { get; set; }
        public Vertex? EndPoint { get; set; }
        public string? StartName { get; set; }
        public string? EndName { get; set; }
        public string? Description { get; set; }
        public double Distance { get; set; }
        public Angle? Angle { get; set; }
    }
}