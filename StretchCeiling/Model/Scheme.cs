using StretchCeiling.Domain.Assistive;
using StretchCeiling.Service.Arithmetic;

namespace StretchCeiling.Model
{
    public class Scheme : IPerimeter, ISquare
    {
        public int Id { get; set; }
        public List<Side> Sides { get; set; }
        public List<Vertex> Points { get; set; }

        public Scheme()
        {
            Sides = new();
            Points = new()
            {
               new Vertex(0,0)
            };
        }

        public List<Vertex> GetPoints()
        {
            var points = new List<Vertex>();
            foreach (Side segment in Sides)
            {
                points.Add(segment.EndPoint);
            }
            return points;
        }

        public double GetPerimeter()
        {
            double perimeter = 0.0;
            if (Sides.Count > 0)
            {
                foreach (var segment in Sides)
                {
                    perimeter += segment.Distance;
                }
                if (Sides.Count > 1)
                {
                    var a = Sides[0].StartPoint;
                    var b = Sides[^1].EndPoint;

                    perimeter += Geometry.Distance(a.X, a.Y, b.X, b.Y);
                }
            }
            return Geometry.ConvertCentimetersToMeters(perimeter);
        }

        public double GetSquare()
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
