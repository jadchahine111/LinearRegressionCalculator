namespace LinearRegressionCalculator.Models
{
    public class Point : IComparable<Point>
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public int CompareTo(Point? other)
        {
            if (other == null)
            {
                return 1;
            }

            int result = X.CompareTo(other.X);
            if (result == 0)
            {
                result = Y.CompareTo(other.Y);
            }
            return result;
        }
    }
}
