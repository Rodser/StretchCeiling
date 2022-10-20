namespace StretchCeiling.DataAccess.Model
{
    public class SideDto
    {
        public VertexDto? StartPoint { get; set; }
        public VertexDto? EndPoint { get; set; }
        public string? StartName { get; set; }
        public string? EndName { get; set; }
        public string? Description { get; set; }
        public double Distance { get; set; }
        public AngleDto? Angle { get; set; }
    }
}
