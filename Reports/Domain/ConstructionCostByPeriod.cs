namespace Reports.Domain
{
    public class ConstructionCostByPeriod
    {
        public int Year { get; set; }
        public int Quarter { get; set; }
        public string Property { get; set; }
        public decimal SquareMeters { get; set; }
        public decimal PlannedCost { get; set; }
        public decimal IncurredCosts { get; set; }
        public decimal Remaining { get; set; }
        public decimal ConstructionCost { get; set; }
        // public bool CommissioningOfResidentialProperty { get; set; }
    }
}
