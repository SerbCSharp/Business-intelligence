using ForecastingModelParameters.Application.DTO;
using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Interfaces
{
    public interface IGetDataRepository
    {
        Task<List<ProjectCostingData>> ProjectCostingDataAsync(string complexProperty);
        Task<List<ReportField>> ReportFieldAsync();
        Task<List<ProjectForecast>> ProjectForecastAsync(string complexProperty);
    }
}
