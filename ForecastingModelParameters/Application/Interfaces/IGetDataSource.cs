using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Interfaces
{
    public interface IGetDataSource
    {
        IEnumerable<ProjectCostingData> ProjectCostingData(string complexProperty);
    }
}
