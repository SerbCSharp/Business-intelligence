using Reports.Domain;

namespace Reports.Application.Interfaces
{
    public interface IGetData
    {
        Task<IEnumerable<ProcurementPrice>> ProcurementPriceAsync();
        Task<IEnumerable<ConstructionCost>> ConstructionCostAsync();
        Task<IEnumerable<CostPerSquareMeter>> CostPerSquareMeterAsync();
        Task<IEnumerable<NonProductionCosts>> NonProductionCostsAsync();
        Task<IEnumerable<ProfitCenters>> ProfitCentersAsync(DateTime startDate, DateTime endDate);
        Task<decimal> OpeningBalanceAsync(DateTime startDate);
    }
}
