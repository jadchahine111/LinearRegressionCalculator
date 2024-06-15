namespace LinearRegressionCalculator.Models
{
    public class LinearRegression
    {
        public Line Line { get; set; }

        public LinearRegression(Line line)
        {
            this.Line = line;
        }

        public double X_SUM()
        {
            double sum = 0;
            Line.Points.InOrderTraversal(point => sum += point.X);
            return sum;
        }

        public double Y_SUM()
        {
            double sum = 0;
            Line.Points.InOrderTraversal(point => sum += point.Y);
            return sum;
        }

        public double X2_SUM()
        {
            double sum = 0;
            Line.Points.InOrderTraversal(point => sum += (point.X * point.X));
            return sum;
        }

        public double Y2_SUM()
        {
            double sum = 0;
            Line.Points.InOrderTraversal(point => sum += (point.Y * point.Y));
            return sum;
        }

        public double XY_SUM()
        {
            double sum = 0;
            Line.Points.InOrderTraversal(point => sum += (point.X * point.Y));
            return sum;
        }

        public double X_AVERAGE()
        {
            int totalPoints = Line.Points.size;
            if (totalPoints != 0)
            {
                double average = X_SUM() / totalPoints;
                return average;
            }

            return Double.NaN;
        }

        public double Y_AVERAGE()
        {
            int totalPoints = Line.Points.size;
            if (totalPoints != 0)
            {
                double average = Y_SUM() / totalPoints;
                return average;
            }

            return Double.NaN;
        }

        // a0
        public double A()
        {
            return Y_AVERAGE() - (B() * X_AVERAGE());
        }

        // a1
        public double B()
        {
            int n = Line.Points.size;
            return ((n * XY_SUM()) - (Y_SUM() * X_SUM())) / ((n * X2_SUM()) - (X_SUM() * X_SUM()));
        }

        public string DisplayLinearRegressionEquation()
        {
            double a0 = A();
            double a1 = B();

            return $"Y = {a1}X + {a0}";
        }

        public double PredicateValue(double X)
        {
            double a0 = A();
            double a1 = B();

            double Y = (a1 * X) + a0;

            return Y;
        }
    }
}
