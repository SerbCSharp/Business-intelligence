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

        public async Task<(List<InterestCostDTO>, double)> InterestCostAsync(string complexProperty, double escrowBalance)
        {
            var projectCostingData = await _getData.ProjectCostingDataAsync(complexProperty, "InterestCost");
            var interest = projectCostingData.First().ProjectCostingDataPeriods.Select(x => new InterestCostDTO
            {
                Year = x.Year,
                Quarter = x.Quarter
            }).ToList();
            interest.Insert(0, new()
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
                    interest[0].EscrowFunding = item.Fact;
                else if (item.Field == "KeyRate")
                    interest[0].KeyRate = item.Fact;
                else if (item.Field == "InterestPayable")
                    interest[0].InterestPayable = item.Fact;
                else if (item.Field == "Principal")
                    interest[0].Principal = item.Fact;

                for (int i = 0; i < item.ProjectCostingDataPeriods.Count; i++)
                {
                    if (item.Field == "KeyRate")
                    {
                        interest[i + 1].KeyRate = item.ProjectCostingDataPeriods[i].Amount;
                        interest[i + 1].TotalCost = item.ProjectCostingDataPeriods[i].TotalCost;
                        interest[i + 1].TotalSales = item.ProjectCostingDataPeriods[i].TotalSales;
                        interest[i + 1].WeightedAverage = 0.045;
                        interest[i + 1].BaseAssessmentRate = 0.12;
                        interest[i + 1].CalculatedInterestRate = 0.1629;
                    }
                    else if (item.Field == "CommissioningOfResidentialProperty")
                    {
                        interest[i + 1].CommissioningOfResidentialProperty = item.ProjectCostingDataPeriods[i].Amount != 0;
                    }
                }
            }
            var interestCostsDTO = CreditCostCalculationMethodology(interest, escrowBalance);

            return (interestCostsDTO, interestCostsDTO.Sum(x => x.AccruedInterest) + interestCostsDTO[0].UnpaidInterest);
        }

        public async Task<IEnumerable<ProjectCostingData>> BuildingCostsAsync(string complexProperty)
        {
            return await _getData.ProjectCostingDataAsync(complexProperty, "BuildingCosts");
        }

        public async Task<IEnumerable<ProjectCostingData>> SalesTargetAsync(string complexProperty)
        {
            return await _getData.ProjectCostingDataAsync(complexProperty, "SalesTarget");
        }

        public async Task<IEnumerable<ProjectCostingData>> OtherCostAsync(string complexProperty)
        {
            return await _getData.ProjectCostingDataAsync(complexProperty, "OtherExpenses");
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

        public List<InterestCostDTO> CreditCostCalculationMethodology(List<InterestCostDTO> interest, double escrowBalance)
        {
            for (int i = 0; i < interest.Count; i++)
            {
                if (i == 0)
                {
                    interest[i].UnpaidInterest = interest[i].InterestPayable - interest[i].InterestPaid;
                    interest[i].PrincipalBalance = interest[i].Principal - interest[i].LoanRepayment;
                    interest[i].TotalPayoffAmount = interest[i].PrincipalBalance + interest[i].UnpaidInterest;
                }
                else
                {
                    interest[i].InterestPayable = interest[i - 1].UnpaidInterest.OrZero() + interest[i - 1].AccruedInterest.OrZero();
                    interest[i].Principal = interest[i - 1].PrincipalBalance + interest[i].TotalCost;
                    interest[i].InterestPaid = interest[i].CommissioningOfResidentialProperty ? interest[i].InterestPayable : 0;
                    var EscrowFundingTmp = interest[i - 1].EscrowFunding + interest[i].TotalSales;
                    if (interest[i].CommissioningOfResidentialProperty)
                    {
                        if ((EscrowFundingTmp - interest[i].InterestPaid - escrowBalance) <= interest[i].Principal)
                        {
                            interest[i].LoanRepayment = EscrowFundingTmp - interest[i].InterestPaid - escrowBalance;
                        }
                        else
                        {
                            interest[i].LoanRepayment = interest[i].Principal;
                            interest[i].EscrowFunding = interest[i - 1].EscrowFunding + interest[i].TotalSales - interest[i].InterestPaid - interest[i].LoanRepayment;
                            return interest;
                        }
                    }
                    else
                    {
                        interest[i].LoanRepayment = 0;
                    }
                    interest[i].PrincipalBalance = interest[i].Principal - interest[i].LoanRepayment;
                    interest[i].UnpaidInterest = interest[i].InterestPayable - interest[i].InterestPaid;
                    interest[i].EscrowFunding = interest[i - 1].EscrowFunding + interest[i].TotalSales - interest[i].InterestPaid - interest[i].LoanRepayment;
                    interest[i].TotalPayoffAmount = interest[i].PrincipalBalance + interest[i].UnpaidInterest;
                }
                interest[i].ProportionOfDebtK1 = interest[i].EscrowFunding * (1 - interest[i].WeightedAverage) / interest[i].TotalPayoffAmount;
                interest[i].ProportionOfDebtK2 = 1 - interest[i].ProportionOfDebtK1;
                interest[i].ConditionK3 = interest[i].EscrowFunding * (1 - interest[i].WeightedAverage) - interest[i].TotalPayoffAmount;
                interest[i].ProportionOfCashK3 = interest[i].ConditionK3 < 0 ? 0 : (interest[i].EscrowFunding * (1 - interest[i].WeightedAverage) -
                    interest[i].TotalPayoffAmount) / interest[i].TotalPayoffAmount;
                interest[i].SpecialCreditRate = (0.0245 + interest[i].BaseAssessmentRate) / (1 - interest[i].WeightedAverage);
                interest[i].BaseLendingRate = 0.056 + interest[i].KeyRate;
                interest[i].DiscountRate = (0.0204 + interest[i].KeyRate) - 0.001 - interest[i].BaseAssessmentRate * (1 - interest[i].WeightedAverage);
                interest[i].CurrentInterestRate = (interest[i].SpecialCreditRate * interest[i].ProportionOfDebtK1) + (interest[i].BaseLendingRate *
                    interest[i].ProportionOfDebtK2) - (interest[i].DiscountRate * interest[i].ProportionOfCashK3);
                interest[i].AccruedInterest = interest[i].CurrentInterestRate * interest[i].Principal * 3 / 12;
            }
            return interest;
        }

        public async Task<IEnumerable<ConstructionCostForecast>> ConstructionCostForecastAsync(string complexProperty, double interestCost)
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
