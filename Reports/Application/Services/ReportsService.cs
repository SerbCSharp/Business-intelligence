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

        public IEnumerable<ProfitCentersDTO> ProfitCenters(IEnumerable<ProfitCentersSource> profitCentersSource)
        {
            var profitCenters = profitCentersSource
                .Where(y => y.AreaOfActivity != "ПереводСДругогоСчета" && y.AreaOfActivity != "ПереводНаДругойСчет")
                .Select(x => new ProfitCentersDTO
                {
                    TypeOfActivity = x.TypeOfActivity,
                    AreaOfActivity = x.AreaOfActivity,
                    Debit = x.DirectOrIndirect ? x.Debit : 0,
                    Credit = x.Credit,
                    IndirectCost = x.DirectOrIndirect ? 0 : x.Debit - x.Credit
                })
                .GroupBy(g => new { g.TypeOfActivity, g.AreaOfActivity })
                .Select(z => new ProfitCentersDTO
                {
                    TypeOfActivity = z.Key.TypeOfActivity,
                    AreaOfActivity = z.Key.AreaOfActivity,
                    Debit = z.Sum(s => s.Debit),
                    Credit = z.Sum(s => s.Credit),
                    IndirectCost = z.Sum(s => s.IndirectCost)
                });
            return profitCenters;
        }

        public async Task<decimal> OpeningBalanceAsync(DateTime startDate)
        {
            return await _getData.OpeningBalanceAsync(startDate);
        }
    }
}
