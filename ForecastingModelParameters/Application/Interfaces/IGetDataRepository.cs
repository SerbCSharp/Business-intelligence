using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Interfaces
{
    public interface IGetDataRepository
    {
        Task<List<ConstructionCostByProperty>> GetConstructionCostByPropertyAsync(string complexProperty);
        Task<List<ConstructionCostByPeriod>> GetConstructionCostByPeriodAsync(string complexProperty);
        Task<List<SalesValueByCategory>> GetSalesValueByCategoryAsync(string complexProperty);
    }
}
