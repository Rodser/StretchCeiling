using StretchCeiling.Service.Arithmetic;
using System.Collections.ObjectModel;

namespace StretchCeiling.Model
{
    public class SchemeCeiling
    {
        public SchemeCeiling()
        {
            Segments = new();
            Points = new()
            {
                Point.Zero
            };
        }

        public int Id { get; set; }
        public ObservableCollection<Segment> Segments { get; set; }
        public PointCollection Points { get; set; }

        public PointCollection GetPoints()
        {
            var points = new PointCollection();
            foreach (var segment in Segments)
            {
                points.Add(segment.EndPoint);
            }
            return points;
        }

        public double GetPerimeter()
        {
            double perimeter = 0.0;
            if (Segments.Count > 0)
            {
                foreach (var segment in Segments)
                {
                    perimeter += segment.Distance;
                }
                if (Segments.Count > 1)
                {
                    var a = Segments[0].StartPoint;
                    var b = Segments[^1].EndPoint;

                    perimeter += Geometry.Distance(a.X, a.Y, b.X, b.Y);
                }
            }
            return Geometry.ConvertCentimetersToMeters(perimeter);
        }

        internal double GetSquare() 
        {
            List<Vertex> vertexes = new();

            foreach (var point in Points)
            {
                Vertex vertex = new(Geometry.ConvertCentimetersToMeters(point.X), Geometry.ConvertCentimetersToMeters(point.Y));
                vertexes.Add(vertex);
            }

            double result = Geometry.GetGaussSquare(vertexes);
            return result;
        }
    }
}
