namespace Reports.Domain
{
    public class NonProductionCosts
    {
        public decimal NonProductionAmount { get; set; }
        public decimal ProductionAmount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
