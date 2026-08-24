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

        public async Task<IEnumerable<ConstructionCostDTO>> ConstructionCostAsync()
        {
            var constructionCost = (await _getData.ConstructionCostAsync()).ToList();
            return constructionCost.Select(x => EstimatingLogic(x));
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
                .Where(y => y.TypeOperation != "ПереводСДругогоСчета" && y.TypeOperation != "ПереводНаДругойСчет")
                .Select(x => new ProfitCentersDTO
                {
                    TypeOfActivity = x.TypeOfActivity,
                    AreaOfActivity = string.IsNullOrEmpty(x.AreaOfActivity) ? x.TypeOperation : x.AreaOfActivity,
                    Debit = x.DirectOrIndirect ? x.Debit : 0,
                    Credit = x.DirectOrIndirect ? x.Credit : 0,
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

        public ConstructionCostDTO EstimatingLogic(ConstructionCost item)
        {
            var contractAmount = item.ContractAmount - item.ContractAmount * item.GeneralContractorMarkup;
            var invoiceAmount = item.InvoiceAmount - item.InvoiceAmount * item.GeneralContractorMarkup;
            var maxAmount = item.Closed ? Math.Max(item.PaymentAmount, invoiceAmount) :
                Math.Max(item.PaymentAmount, Math.Max(contractAmount, invoiceAmount));

            return new ConstructionCostDTO
            {
                ConstructionCost = maxAmount,
                ConstructionCostPlusVATDifference = maxAmount * (1.22M - item.VATRate),
                ContractAmount = item.ContractAmount,
                InvoiceAmount = item.InvoiceAmount,
                PaymentAmount = item.PaymentAmount,
                Contractor = item.Contractor,
                Number = item.Number,
                Date = item.Date,
                Property = item.Property,
                CostItem = item.CostItem,
            };
        }

        public async Task<IEnumerable<ConstructionCostByPeriod>> ConstructionCostByPeriodAsync(string complexProperty)
        {
            return await _getData.ConstructionCostByPeriodAsync(complexProperty);
        }
    }
}
