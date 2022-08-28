using Rodser.Library;
using System.Collections.ObjectModel;

namespace StretchCeiling.Model
{
    public class SchemeCeiling
    {
        public SchemeCeiling()
        {
            Segments = new ();
            Points = new ()
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
            double p = 0.0;
            if (Segments.Count > 0)
            {
                foreach (var segment in Segments)
                {
                    p += segment.Distance;
                }
                if (Segments.Count > 1)
                {
                    var a = Segments[0].StartPoint;
                    var b = Segments[^1].EndPoint;
                    
                    p += Geometry.Distance(a.X, a.Y, b.X, b.Y);
                }
            }
            return p;
        }
    }
}
