namespace StretchCeiling.Service.Arithmetic
{
    public static class Geometry
    {
        /// <summary>
        /// Дистанция между двумя точками
        /// </summary>
        /// <param name="x1">Х координата начальной точки</param>
        /// <param name="y1">Y координата начальной точки</param>
        /// <param name="x2">X координата конечной точки</param>
        /// <param name="y2">Y координата конечной точки</param>
        /// <returns>double</returns>
        public static double Distance(double x1, double y1, double x2, double y2)
        {
            return GetDistance(x2 - x1, y2 - y1);
        }

        /// <summary>
        /// Расчитывает площадь многоугоольника, вершины которого заданы декартовыми координатами (по формуле Гаусса).
        /// </summary>
        /// <param name="points">Координаты вершин многоугольника</param>
        /// <returns></returns>
        public static double GetGaussSquare(IList<Vertex> points)
        {
            double square = 0;
            for (int i = 0; i < points.Count; i++)
            {
                double xi = points[i].X;
                double yi = points[i].Y;
                double xj = i + 1 < points.Count ? points[i + 1].X : points[0].X;
                double yj = i + 1 < points.Count ? points[i + 1].Y : points[0].Y;

                square += xi * yj - xj * yi;
            }
            square = Math.Abs(square);

            return square * 0.5;
        }

        public static double ConvertCentimetersToMeters(double value)
        {
            return value * 0.01;
        }

        private static double GetDistance(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }
    }
}