using Reports.Domain;

namespace Reports.Application.Interfaces
{
    public interface IGetData
    {
        Task<IEnumerable<ProcurementPrice>> ProcurementPriceAsync();
        Task<IEnumerable<ConstructionCost>> ConstructionCostAsync();
        Task<IEnumerable<CostPerSquareMeter>> CostPerSquareMeterAsync();
        Task<IEnumerable<NonProductionCosts>> NonProductionCostsAsync();
        Task<IEnumerable<ProfitCentersSource>> ProfitCentersSourceAsync(DateTime startDate, DateTime endDate);
        Task<decimal> OpeningBalanceAsync(DateTime startDate);
        Task<IEnumerable<ConstructionCostByPeriod>> ConstructionCostByPeriodAsync(string complexProperty);
        Task<IEnumerable<SalesTarget>> SalesTargetAsync(string complexProperty);
        Task<IEnumerable<OtherCost>> OtherCostAsync(string complexProperty);
        Task<IEnumerable<InterestCost>> InterestCostAsync(string complexProperty);
        Task<IEnumerable<ConstructionCostForecast>> ConstructionCostForecastAsync(string complexProperty);
    }
}
