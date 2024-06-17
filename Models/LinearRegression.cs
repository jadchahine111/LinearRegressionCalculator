namespace LinearRegressionCalculator.Models
{
    public class LinearRegression
    {
        public Dataset Data { get; set; }

        public LinearRegression(Dataset data)
        {
            Data = data;
        }


        /*      n(Σxy) - (Σx)(Σy)
            a = -----------------
                  n(Σx²) - (Σx)²
        */
        public double CalculateA()
        {
            int n = Data.PointsCount;
            double sumXY = Data.CalculateSumXY();
            double sumX = Data.CalculateSumX();
            double sumY = Data.CalculateSumY();
            double sumX2 = Data.CalculateSumX2();

            return (n * sumXY - sumX * sumY) / (n * sumX2 - Math.Pow(sumX, 2));
        }

        /*
             b = ȳ - ax̄
        */
        public double CalculateB()
        {
            return Data.CalculateAverageY() - CalculateA() * Data.CalculateAverageX();
        }

        public double Predict(double x)
        {
            return CalculateA() * x + CalculateB();
        }

        // Draw line by calculate 3 or more points
        public List<Point> DrawLine(int numberOfPoints = 100, double xStart = 0, double xEnd = 10)
        {
            List<Point> points = new List<Point>();
            double step = (xEnd - xStart) / (numberOfPoints - 1);

            for (int i = 0; i < numberOfPoints; i++)
            {
                double x = xStart + i * step;
                double y = Predict(x);
                points.Add(new Point(x, y));
            }

            return points;
        }

        public double SSE()
        {
            double result = 0;
            foreach (var point in Data.Points)
            {
                result += Math.Pow((point.Y - Predict(point.X)), 2);
            }
            return result;
        }

        public double MSE()
        {
            int n = Data.PointsCount;
            return SSE() / n;
        }

        public double RMSE()
        {
            return Math.Sqrt(MSE());
        }

        public double NRMSE()
        {
            return RMSE() / Data.CalculateAverageY();
        }
    }
}
