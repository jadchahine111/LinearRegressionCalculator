using LinearRegressionCalculator.Models;

namespace LinearRegressionCalculator.Services
{
    public interface IUserService
    {
        public Table CreateTable(Dataset dataset);
    }
}
