namespace LinearRegressionCalculator.Models
{
    public class Line
    {
        public BST<Point> Points { get; set; }

        public Line()
        {
            Points = new BST<Point>();
        }

        public void AddPoint(Point point)
        {
            Points.Insert(point);
        }

        public bool SearchPoint(Point point)
        {
            return Points.Search(point);
        }

        public void RemovePoint(Point point)
        {
            Points.Delete(point);
        }

        public void DisplayPoints()
        {
            Points.InOrderTraversal(point => Console.WriteLine($"X: {point.X}, Y: {point.Y}"));
        }
    }
}
