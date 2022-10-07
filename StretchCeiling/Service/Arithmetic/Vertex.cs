namespace StretchCeiling.Service.Arithmetic
{
    public struct Vertex
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vertex(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static PointCollection ToPointCollection(List<Vertex> vertices)
        {
            PointCollection points = new PointCollection();
            foreach (Vertex vertex in vertices)
            {
                Point point = new(vertex.X, vertex.Y);
                points.Add(point);
            }
            return points;
        }
    }
}