using OfficeOpenXml.Attributes;

namespace Reports.Application.DTO
{
    public class InterestCostDTO
    {
        [EpplusTableColumn(Header = "Год", NumberFormat = "###0")]
        public int Year { get; set; }

        [EpplusTableColumn(Header = "Квартал", NumberFormat = "###0")]
        public int Quarter { get; set; }

        [EpplusIgnore]
        public decimal TotalSales { get; set; }

        [EpplusIgnore]
        public decimal TotalCost { get; set; }

        [EpplusTableColumn(Header = "Наполнение Эскроу-счетов (после погашения)", NumberFormat = "### ### ### ##0.00")]
        public decimal EscrowFunding { get; set; }
        public decimal InterestPayable { get; set; }
        public decimal InterestPaid { get; set; }
        public decimal UnpaidInterest { get; set; }
        public decimal Principal { get; set; }
        public decimal LoanRepayment { get; set; }
        public decimal PrincipalBalance { get; set; }
        public decimal TotalPayoffAmount { get; set; }
        public decimal ProportionOfDebtK1 { get; set; }
        public decimal ProportionOfDebtK2 { get; set; }
        public decimal ProportionOfCashK3 { get; set; }
        public decimal ConditionK3 { get; set; }
        public decimal KeyRate { get; set; }
        public decimal WeightedAverage { get; set; }
        public decimal BaseAssessmentRate { get; set; }
        public decimal SpecialCreditRate { get; set; }
        public decimal BaseLendingRate { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal CalculatedInterestRate { get; set; }

        [EpplusTableColumn(Header = "СтКрРасч", NumberFormat = "##0.0000")]
        public decimal CurrentInterestRate { get; set; }
        public decimal AccruedInterest { get; set; }

        [EpplusIgnore]
        public bool CommissioningOfResidentialProperty { get; set; }
    }
}
