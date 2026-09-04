using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Interfaces
{
    public interface IGetDataRepository
    {
        Task<List<ReportField>> ReportFieldAsync();
    }
}
