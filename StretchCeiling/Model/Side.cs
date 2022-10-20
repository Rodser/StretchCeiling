using StretchCeiling.Service.Arithmetic;

namespace StretchCeiling.Model
{
    public class Side
    {
        private readonly List<Vertex> _points;

        public Vertex StartPoint { get; set; }
        public Vertex EndPoint { get; set; }
        public string StartName { get; set; }
        public string EndName { get; set; }
        public string Description { get; set; }
        public double Distance { get; set; }
        public Angle Angle { get; set; }

        public Side() {}

        public Side(Vertex startPoint, Vertex endPoint, Angle angle)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Angle = angle;
        }

        public Side(List<Vertex> points, double distance, Angle angle)
        {
            _points = points;
            StartPoint = _points[_points.Count - 2];
            StartName = GetNameOfPoint(_points.Count - 2);
            EndPoint =  _points[_points.Count - 1];
            EndName = GetNameOfPoint(_points.Count - 1);
            Distance = distance;
            Angle = angle;
            Description = $"{StartName}{EndName}";
        }

        private string GetNameOfPoint(int index)
        {
            return Convert.ToChar(index + 65).ToString();
        }

        public override string ToString()
        {
            return $"{StartName}{EndName} : {Distance} ";
        }
    }
}
