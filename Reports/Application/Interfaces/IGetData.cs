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

        Task<IEnumerable<ProjectCostingData>> ProjectCostingDataAsync(string complexProperty, string storedProcedureName);
        Task<IEnumerable<ConstructionCostForecast>> ConstructionCostForecastAsync(string complexProperty);

        Task<IEnumerable<Revenue>> RevenueAsync(string complexProperty);
        Task<IEnumerable<ConstructionExpense>> ConstructionExpenseAsync(string complexProperty);
        Task<IEnumerable<OtherExpense>> OtherExpenseAsync(string complexProperty);
        Task<IEnumerable<ReportStructure>> ReportStructureAsync();
    }
}
