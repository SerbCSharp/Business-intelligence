using Reports.Application.DTO;
using Reports.Application.Interfaces;
using Reports.Domain;
using System.Reflection;

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

        public async Task<IEnumerable<ConstructionCostByPeriod>> ConstructionCostByPeriodAsync(string complexProperty)
        {
            return await _getData.ConstructionCostByPeriodAsync(complexProperty);
        }

        public async Task<IEnumerable<SalesTarget>> SalesTargetAsync(string complexProperty)
        {
            return await _getData.SalesTargetAsync(complexProperty);
        }

        public async Task<IEnumerable<OtherCost>> OtherCostAsync(string complexProperty)
        {
            return await _getData.OtherCostAsync(complexProperty);
        }

        public async Task<(IEnumerable<InterestCostDTO>, decimal)> InterestCostAsync(string complexProperty)
        {
            var interestCost = (await _getData.InterestCostAsync(complexProperty)).ToList();

            var interestCostsDTO = new List<InterestCostDTO> { new() };
            interestCostsDTO[0].EscrowFunding = interestCost[0].IncurredCosts;
            interestCostsDTO[0].InterestPayable = interestCost[1].IncurredCosts;
            interestCostsDTO[0].Principal = interestCost[4].IncurredCosts;
            interestCostsDTO[0].KeyRate = interestCost[12].PercentageOfCosts;
            interestCostsDTO[0].WeightedAverage = interestCost[13].PercentageOfCosts;
            interestCostsDTO[0].BaseAssessmentRate = interestCost[14].PercentageOfCosts;
            interestCostsDTO[0].CalculatedInterestRate = interestCost[18].PercentageOfCosts;
            interestCostsDTO[0].UnpaidInterest = interestCost[1].IncurredCosts - interestCost[2].IncurredCosts;
            interestCostsDTO[0].PrincipalBalance = interestCost[4].IncurredCosts - interestCost[5].IncurredCosts;

            interestCostsDTO[0].TotalPayoffAmount = interestCostsDTO[0].PrincipalBalance + interestCostsDTO[0].UnpaidInterest;

            interestCostsDTO[0].ProportionOfDebtK1 = interestCostsDTO[0].TotalPayoffAmount == decimal.Zero ? decimal.Zero : 
                interestCostsDTO[0].EscrowFunding * (1 - interestCostsDTO[0].WeightedAverage) / interestCostsDTO[0].TotalPayoffAmount;

            interestCostsDTO[0].ProportionOfDebtK2 = 1 - interestCostsDTO[0].ProportionOfDebtK1;
            interestCostsDTO[0].ConditionK3 = interestCostsDTO[0].EscrowFunding * (1 - interestCostsDTO[0].WeightedAverage) - interestCostsDTO[0].TotalPayoffAmount;
            interestCostsDTO[0].ProportionOfCashK3 = interestCostsDTO[0].ConditionK3 < 0 ? 0 :

                interestCostsDTO[0].TotalPayoffAmount == decimal.Zero ? decimal.Zero : 
                    interestCostsDTO[0].TotalPayoffAmount == decimal.Zero ? decimal.Zero : (interestCostsDTO[0].EscrowFunding * (1 - interestCostsDTO[0].WeightedAverage) - interestCostsDTO[0].TotalPayoffAmount) / interestCostsDTO[0].TotalPayoffAmount;

            interestCostsDTO[0].SpecialCreditRate = (0.0245M + interestCostsDTO[0].BaseAssessmentRate) / (1 - interestCostsDTO[0].WeightedAverage);
            interestCostsDTO[0].BaseLendingRate = 0.056M + interestCostsDTO[0].KeyRate;
            interestCostsDTO[0].DiscountRate =
                (0.0204M + interestCostsDTO[0].KeyRate) - 0.001M - interestCostsDTO[0].BaseAssessmentRate * (1 - interestCostsDTO[0].WeightedAverage);
            interestCostsDTO[0].CurrentInterestRate =
                (interestCostsDTO[0].SpecialCreditRate * interestCostsDTO[0].ProportionOfDebtK1) +
                (interestCostsDTO[0].BaseLendingRate * interestCostsDTO[0].ProportionOfDebtK2) -
                (interestCostsDTO[0].DiscountRate * interestCostsDTO[0].ProportionOfCashK3);
            interestCostsDTO[0].AccruedInterest = interestCostsDTO[0].CurrentInterestRate * interestCostsDTO[0].Principal * 3 / 12;

            var quarter = 0;
            var j = 0;

            for (int i = 0; i < interestCost.Count; i++)
            {
                if (interestCost[i].Quarter == quarter)
                {
                    if (interestCost[i].Field == "KeyRate")
                        interestCostsDTO[j].KeyRate = interestCost[i].PercentageOfCostsByPeriods;
                    if (interestCost[i].Field == "Principal")
                        interestCostsDTO[j].TotalCost = interestCost[i].TotalCost;
                }
                else
                {
                    j++;
                    interestCostsDTO.Add(new InterestCostDTO());
                    interestCostsDTO[j].TotalSales = interestCost[i].TotalSales;
                    interestCostsDTO[j].CommissioningOfResidentialProperty = interestCost[i].CommissioningOfResidentialProperty;
                    interestCostsDTO[j].Year = interestCost[i].Year;
                    interestCostsDTO[j].Quarter = interestCost[i].Quarter;
                }
                quarter = interestCost[i].Quarter;
            }

            for (int i = 1; i < interestCostsDTO.Count; i++)
            {
                interestCostsDTO[i].InterestPayable = interestCostsDTO[i - 1].UnpaidInterest + interestCostsDTO[i - 1].AccruedInterest;
                
                interestCostsDTO[i].Principal = interestCostsDTO[i - 1].PrincipalBalance + interestCostsDTO[i].TotalCost;
                interestCostsDTO[i].InterestPaid = interestCostsDTO[i].CommissioningOfResidentialProperty ? interestCostsDTO[i].InterestPayable : 0;

                var EscrowFundingTmp = interestCostsDTO[i - 1].EscrowFunding + interestCostsDTO[i].TotalSales;

                interestCostsDTO[i].LoanRepayment = interestCostsDTO[i].CommissioningOfResidentialProperty ? EscrowFundingTmp - interestCostsDTO[i].InterestPaid - 900000000 : 0;
                interestCostsDTO[i].PrincipalBalance = interestCostsDTO[i].Principal - interestCostsDTO[i].LoanRepayment;

                interestCostsDTO[i].UnpaidInterest = interestCostsDTO[i].InterestPayable - interestCostsDTO[i].InterestPaid;

                interestCostsDTO[i].EscrowFunding = interestCostsDTO[i - 1].EscrowFunding + interestCostsDTO[i].TotalSales - interestCostsDTO[i].InterestPaid - interestCostsDTO[i].LoanRepayment;


                interestCostsDTO[i].TotalPayoffAmount = interestCostsDTO[i].PrincipalBalance + interestCostsDTO[i].UnpaidInterest;


                interestCostsDTO[i].WeightedAverage = interestCostsDTO[0].WeightedAverage;
                interestCostsDTO[i].BaseAssessmentRate = interestCostsDTO[0].BaseAssessmentRate;
                interestCostsDTO[i].CalculatedInterestRate = interestCostsDTO[0].CalculatedInterestRate;


                interestCostsDTO[i].ProportionOfDebtK1 = interestCostsDTO[i].EscrowFunding * (1 - interestCostsDTO[i].WeightedAverage) / interestCostsDTO[i].TotalPayoffAmount;
                interestCostsDTO[i].ProportionOfDebtK2 = 1 - interestCostsDTO[i].ProportionOfDebtK1;
                interestCostsDTO[i].ConditionK3 = interestCostsDTO[i].EscrowFunding * (1 - interestCostsDTO[i].WeightedAverage) - interestCostsDTO[i].TotalPayoffAmount;
                interestCostsDTO[i].ProportionOfCashK3 = interestCostsDTO[i].ConditionK3 < 0 ? 0 :
                    (interestCostsDTO[i].EscrowFunding * (1 - interestCostsDTO[i].WeightedAverage) - interestCostsDTO[i].TotalPayoffAmount) / interestCostsDTO[i].TotalPayoffAmount;
                interestCostsDTO[i].SpecialCreditRate = (0.0245M + interestCostsDTO[i].BaseAssessmentRate) / (1 - interestCostsDTO[i].WeightedAverage);
                interestCostsDTO[i].BaseLendingRate = 0.056M + interestCostsDTO[i].KeyRate;
                interestCostsDTO[i].DiscountRate =
                    (0.0204M + interestCostsDTO[i].KeyRate) - 0.001M - interestCostsDTO[i].BaseAssessmentRate * (1 - interestCostsDTO[i].WeightedAverage);
                interestCostsDTO[i].CurrentInterestRate =
                    (interestCostsDTO[i].SpecialCreditRate * interestCostsDTO[i].ProportionOfDebtK1) +
                    (interestCostsDTO[i].BaseLendingRate * interestCostsDTO[i].ProportionOfDebtK2) -
                    (interestCostsDTO[i].DiscountRate * interestCostsDTO[i].ProportionOfCashK3);
                interestCostsDTO[i].AccruedInterest = interestCostsDTO[i].CurrentInterestRate * interestCostsDTO[i].Principal * 3 / 12;
            }

            return (interestCostsDTO, interestCostsDTO.Sum(x => x.AccruedInterest) + interestCostsDTO[0].UnpaidInterest);
        }

        public async Task<IEnumerable<ConstructionCostForecast>> ConstructionCostForecastAsync(string complexProperty, decimal interestCost)
        {
            var constructionCostForecast = await _getData.ConstructionCostForecastAsync(complexProperty);
            var result = constructionCostForecast.Select(x => new ConstructionCostForecast
            {
                Name = x.Name,
                Amount = x.Field == "InterestCost" ? interestCost : x.Amount
            });
            return result;
        }
    }
}
