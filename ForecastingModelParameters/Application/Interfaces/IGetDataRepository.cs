using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Interfaces
{
    public interface IGetDataRepository
    {
        Task<List<ConstructionCostByProperty>> GetConstructionCostByPropertyAsync(string complexProperty);
        Task<List<ConstructionCostByPeriod>> GetConstructionCostByPeriodAsync(string complexProperty);
        Task<List<SalesValueByCategory>> GetSalesValueByCategoryAsync(string complexProperty);
        Task<List<SalesValueByPeriod>> GetSalesValueByPeriodAsync(string complexProperty);
        Task<List<OtherFixedCost>> GetOtherFixedCostAsync(string complexProperty);
        Task<List<OtherFixedCostByPeriod>> GetOtherFixedCostByPeriodAsync(string complexProperty);
        Task<List<OtherPercentageCost>> GetOtherPercentageCostAsync(string complexProperty);
        Task<List<OtherPercentageCostByPeriod>> GetOtherPercentageCostByPeriodAsync(string complexProperty);
        Task<List<ReportField>> GetReportFieldAsync();
    }
}
