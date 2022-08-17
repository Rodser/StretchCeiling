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
    }
}
