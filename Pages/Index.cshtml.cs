using LinearRegressionCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LinearRegressionCalculator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<Point> Coordinates { get; set; } = new List<Point>();
        public Line Line { get; set; }
        
        public LinearRegression linearRegression { get; set; }



        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(List<Point> coordinates)
        {
            Coordinates = coordinates;

            // Add each coordinate as a point to the Line
            foreach (var point in coordinates)
            {
                Line.AddPoint(point);
            }
            linearRegression.Line = Line;
            double a0 = linearRegression.B();
            double a1 = linearRegression.A();
            return Page();
        }
    }
}
