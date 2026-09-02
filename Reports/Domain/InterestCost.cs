namespace Reports.Domain
{
    public class InterestCost
    {
        public string Name { get; set; }
        public decimal IncurredCosts { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }
        public int LineNumber { get; set; }
        public string Field { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalCost { get; set; }
        public decimal PercentageOfCosts { get; set; }
        public decimal PercentageOfCostsByPeriods { get; set; }
        public bool CommissioningOfResidentialProperty { get; set; }
    }
}
