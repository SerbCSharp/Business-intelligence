using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Interfaces
{
    public interface IGetDataSource
    {
        IEnumerable<ConstructionCostByProperty> GetConstructionCostByProperty(string complexProperty);
    }
}
