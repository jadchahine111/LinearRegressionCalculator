namespace LinearRegressionCalculator.Models
{
    public class Row
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double XY { get; set; }
        public double X2 { get; set; }
        public double YHat { get; set; }
        public double E { get; set; }
        public double E2 { get; set; }

        public Row(double x, double y, double yHat)
        {
            X = x;
            Y = y;
            YHat = yHat;
            XY = x * y;
            X2 = x * x;
            E = Math.Abs(y - yHat);
            E2 = E * E;
        }
    }
}
