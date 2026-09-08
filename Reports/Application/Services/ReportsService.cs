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
            return constructionCost.Select(EstimatingLogic).OrderBy(y => y.Contractor).ThenBy(z => z.Name);
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

        public async Task<IEnumerable<InterestCostDTO>> InterestCostAsync(string complexProperty)
        {
            var projectCostingData = await _getData.ProjectCostingDataAsync(complexProperty);
            var interestCostsDTO = projectCostingData.First().ProjectCostingDataPeriods.Select(x => new InterestCostDTO
            {
                Year = x.Year,
                Quarter = x.Quarter
            }).ToList();
            interestCostsDTO.Insert(0, new()
            { 
                Year = 0,
                Quarter = 0,
                WeightedAverage = 0.045,
                BaseAssessmentRate = 0.12,
                CalculatedInterestRate = 0.1629
            });

            foreach (var item in projectCostingData)
            {
                if (item.Field == "EscrowFunding")
                    interestCostsDTO[0].EscrowFunding = item.Fact;
                else if (item.Field == "KeyRate")
                    interestCostsDTO[0].KeyRate = item.Fact;
                else if (item.Field == "InterestPayable")
                    interestCostsDTO[0].InterestPayable = item.Fact;
                else if (item.Field == "Principal")
                    interestCostsDTO[0].Principal = item.Fact;

                for (int i = 0; i < item.ProjectCostingDataPeriods.Count; i++)
                {
                    if (item.Field == "KeyRate")
                    {
                        interestCostsDTO[i + 1].KeyRate = item.ProjectCostingDataPeriods[i].Amount;
                        interestCostsDTO[i + 1].WeightedAverage = 0.045;
                        interestCostsDTO[i + 1].BaseAssessmentRate = 0.12;
                        interestCostsDTO[i + 1].CalculatedInterestRate = 0.1629;
                    }
                }
            }

            foreach (var item in interestCostsDTO)
            {
                if (item.Year == 0)
                {
                    item.UnpaidInterest = item.InterestPayable - item.InterestPaid;
                    item.PrincipalBalance = item.Principal - item.LoanRepayment;
                    item.TotalPayoffAmount = item.PrincipalBalance + item.UnpaidInterest;
                    item.ProportionOfDebtK1 = item.EscrowFunding * (1 - item.WeightedAverage) / item.TotalPayoffAmount;

                    item.ProportionOfDebtK2 = 1 - item.ProportionOfDebtK1;
                    item.ConditionK3 = item.EscrowFunding * (1 - item.WeightedAverage) - item.TotalPayoffAmount;
                    item.ProportionOfCashK3 = item.ConditionK3 < 0 ? 0 : (item.EscrowFunding * (1 - item.WeightedAverage) - item.TotalPayoffAmount) / item.TotalPayoffAmount;

                    item.SpecialCreditRate = (0.0245 + item.BaseAssessmentRate) / (1 - item.WeightedAverage);
                    interestCostsDTO[0].BaseLendingRate = 0.056M + interestCostsDTO[0].KeyRate;
                    interestCostsDTO[0].DiscountRate =
                        (0.0204M + interestCostsDTO[0].KeyRate) - 0.001M - interestCostsDTO[0].BaseAssessmentRate * (1 - interestCostsDTO[0].WeightedAverage);
                    interestCostsDTO[0].CurrentInterestRate =
                        (interestCostsDTO[0].SpecialCreditRate * interestCostsDTO[0].ProportionOfDebtK1) +
                        (interestCostsDTO[0].BaseLendingRate * interestCostsDTO[0].ProportionOfDebtK2) -
                        (interestCostsDTO[0].DiscountRate * interestCostsDTO[0].ProportionOfCashK3);
                    interestCostsDTO[0].AccruedInterest = interestCostsDTO[0].CurrentInterestRate * interestCostsDTO[0].Principal * 3 / 12;
                }
                else
                {

                }
            }
            return interestCostsDTO;
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
                ContractAmount = item.ContractAmount,
                InvoiceAmount = item.InvoiceAmount,
                PaymentAmount = item.PaymentAmount,
                Contractor = item.Contractor,
                Name = item.Name,
                Date = item.Date,
                Property = item.Property,
                CostItem = item.CostItem,
                GeneralContractorMarkup = item.GeneralContractorMarkup,
                ContractorOrSupplier = item.ContractorOrSupplier,
                VATRate = item.VATRate
            };
        }
    }
}
