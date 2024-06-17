using LinearRegressionCalculator.Models;
using LinearRegressionCalculator.Services;

namespace LinearRegressionSimulation.Services
{
    public class UserService : IUserService
    {
        public Table CreateTable(Dataset dataset)
        {
            Table table = new Table();
            LinearRegression linearRegression = new LinearRegression(dataset);

            foreach (var point in dataset.Points)
            {
                table.AddRow(new Row(point.X, point.Y, linearRegression.Predict(point.X)));
            }

            return table;
        }
    }
}
