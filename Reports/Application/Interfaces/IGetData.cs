using Reports.Domain;

namespace Reports.Application.Interfaces
{
    public interface IGetData
    {
        Task<IEnumerable<ProcurementPrice>> ProcurementPriceAsync();
        Task<IEnumerable<CostVsValue>> CostVsValueAsync();
        Task<IEnumerable<ConstructionCost>> ConstructionCostAsync();
        Task<IEnumerable<CostPerSquareMeter>> CostPerSquareMeterAsync();
    }
}
