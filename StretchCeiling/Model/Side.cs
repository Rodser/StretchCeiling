using StretchCeiling.Domain;
using StretchCeiling.Domain.Model;

namespace StretchCeiling.Model
{
    public class Side : ISide
    {
        private readonly List<IVertex> _points;

        public Side()
        {
        }

        public Side(List<IVertex> points, double distance, Angle angle)
        {
            _points = points;
            StartPoint = _points[_points.Count - 2];
            StartName = GetNameOfPoint(_points.Count - 2);
            EndPoint = _points[_points.Count - 1];
            EndName = GetNameOfPoint(_points.Count - 1);
            Distance = distance;
            Angle = angle;
            Description = $"{StartName}{EndName}";
        }

        public IVertex StartPoint { get; set; }
        public IVertex EndPoint { get; set; }
        public string StartName { get; set; }
        public string EndName { get; set; }
        public string Description { get; set; }
        public double Distance { get; set; }
        public IAngle Angle { get; set; }

        private string GetNameOfPoint(int index)
        {
            return Convert.ToChar(index + 65).ToString();
        }

        public override string ToString()
        {
            return $"{StartName}{EndName} : {Distance}";
        }
    }
}
