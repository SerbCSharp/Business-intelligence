namespace ForecastingModelParameters.Application.Interfaces
{
    public interface IGetDataSource
    {
        IEnumerable<T> GetProjectCostingData<T>(string complexProperty, string name);
    }
}
