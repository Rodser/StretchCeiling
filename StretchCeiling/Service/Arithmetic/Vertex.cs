using StretchCeiling.Domain.Model;

namespace StretchCeiling.Service.Arithmetic
{
    public struct Vertex : IVertex
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vertex(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}