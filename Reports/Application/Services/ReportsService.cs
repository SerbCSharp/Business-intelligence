using Reports.Application.DTO;
using Reports.Application.Interfaces;
using Reports.Domain;

namespace Reports.Application.Services
{
    public class ReportsService(IGetData getData)
    {
        private readonly IGetData _getData = getData;

        public async Task<IEnumerable<ProcurementPrice>> ProcurementPriceAsync()
        {
            return await _getData.ProcurementPriceAsync();
        }

        public async Task<IEnumerable<ConstructionCost>> ConstructionCostAsync()
        {
            return await _getData.ConstructionCostAsync();
        }

        public async Task<IEnumerable<CostPerSquareMeter>> CostPerSquareMeterAsync()
        {
            return await _getData.CostPerSquareMeterAsync();
        }

        public async Task<IEnumerable<NonProductionCosts>> NonProductionCostsAsync()
        {
            return await _getData.NonProductionCostsAsync();
        }

        public async Task<IEnumerable<ProfitCentersSource>> ProfitCentersSourceAsync(DateTime startDate, DateTime endDate)
        {
            return await _getData.ProfitCentersSourceAsync(startDate, endDate);
        }

        public async Task<IEnumerable<ProfitCentersDTO>> ProfitCentersAsync(IEnumerable<ProfitCentersSource> profitCentersSource)
        {
        }

        public async Task<decimal> OpeningBalanceAsync(DateTime startDate)
        {
            return await _getData.OpeningBalanceAsync(startDate);
        }
    }
}
