namespace Reports.Application.DTO
{
    public class InterestCostDTO
    {
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
        public decimal CurrentInterestRate { get; set; }
        public decimal AccruedInterest { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }
        public bool CommissioningOfResidentialProperty { get; set; }
    }
}
