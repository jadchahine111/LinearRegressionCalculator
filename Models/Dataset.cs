namespace LinearRegressionCalculator.Models
{
    public class Dataset
    {
        public List<Point> Points { get; set; }

        // n
        public int PointsCount => Points.Count;

        public Dataset()
        {
            Points = new List<Point>();
        }

        public void AddPoint(Point p)
        {
            Points.Add(p);
        }

        public void RemovePoint(Point p)
        {
            Points.Remove(p);
        }

        public void Clear()
        {
            Points.Clear();
        }

        public double CalculateSumX()
        {
            return Points.Sum(point => point.X);
        }

        public double CalculateSumY()
        {
            return Points.Sum(point => point.Y);
        }

        public double CalculateSumXY()
        {
            return Points.Sum(point => point.X * point.Y);
        }

        public double CalculateSumX2()
        {
            return Points.Sum(point => point.X * point.X);
        }

        public double CalculateAverageX()
        {
            return PointsCount > 0 ? CalculateSumX() / PointsCount : 0;
        }

        public double CalculateAverageY()
        {
            return PointsCount > 0 ? CalculateSumY() / PointsCount : 0;
        }
    }
}
