using System.ComponentModel.DataAnnotations;

namespace LinearRegressionCalculator.Models
{
    public class Point
    {
        [Required]
        [Display(Name = "X Value.")]
        public double X { get; set; }

        [Required]
        [Display(Name = "Y Value.")]
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point() { }

        public string DisplayPoint()
        {
            return ($"({X},{Y})");
        }
    }
}
