namespace ForecastingModelParameters.Application.Interfaces
{
    public interface IGetDataSource
    {
        IEnumerable<T> ProjectCostingData<T>(string complexProperty, string name);
    }
}
