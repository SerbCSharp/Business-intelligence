using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Interfaces
{
    public interface IGetDataRepository
    {
        Task<List<ConstructionCostByProperty>> GetConstructionCostByPropertyAsync(string complexProperty);
        Task<List<ConstructionCostByPeriod>> GetConstructionCostByPeriodAsync(string complexProperty);
        Task<List<SalesValueByCategory>> GetSalesValueByCategoryAsync(string complexProperty);
        Task<List<SalesValueByPeriod>> GetSalesValueByPeriodAsync(string complexProperty);
        Task<List<OtherCost>> GetOtherCostAsync(string complexProperty);
        Task<List<OtherCostByPeriod>> GetOtherCostByPeriodAsync(string complexProperty);
        Task<List<ReportField>> GetReportFieldAsync();
    }
}
