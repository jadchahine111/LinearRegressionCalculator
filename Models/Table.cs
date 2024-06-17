namespace LinearRegressionCalculator.Models
{
    public class Table
    {
        public List<Row> Rows { get; set; } = new List<Row>();

        public void AddRow(Row row)
        {
            Rows.Add(row);
        }

        public void RemoveRow(Row row)
        {
            Rows.Remove(row);
        }

        public void Clear()
        {
            Rows.Clear();
        }

        public List<Point> GetDataPoints()
        {
            List<Point> points = new List<Point>();
            foreach (var row in Rows)
            {
                Point p = new Point(row.X, row.Y);
                points.Add(p);
            }
            return points;
        }

        public List<Point> GetLinePoints()
        {
            List<Point> points = new List<Point>();
            foreach (var row in Rows)
            {
                Point p = new Point(row.X, row.YHat);
                points.Add(p);
            }
            return points;
        }
    }
}
