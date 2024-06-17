using LinearRegressionCalculator.Models;
using LinearRegressionCalculator.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace LinearRegressionCalculator.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public List<Point> Points { get; set; } = new List<Point>();

        public string LineData { get; set; }
        public string PointsData { get; set; }

        public double A { get; set; }
        public double B { get; set; }

        public double NRMSE { get; set; }

        public Table Table { get; set; } = new Table();

        public void OnPost()
        {
            var dataset = new Dataset();

            foreach (var point in Points)
            {
                dataset.AddPoint(new Point(point.X, point.Y));
            }

            if (dataset.PointsCount >= 2)
            {

                Table = _userService.CreateTable(dataset);

                LinearRegression lr = new LinearRegression(dataset);

                A = lr.CalculateA();
                B = lr.CalculateB();

                NRMSE = lr.NRMSE();

                var lineData = Table.GetLinePoints().Select(p => new { x = p.X, y = p.Y }).ToList();
                LineData = JsonConvert.SerializeObject(lineData);

                var pointsData = Table.GetDataPoints().Select(p => new { x = p.X, y = p.Y }).ToList();
                PointsData = JsonConvert.SerializeObject(pointsData);

            }
        }
    }
}
