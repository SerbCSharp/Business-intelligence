namespace Reports.Domain
{
    public class ProjectCostingDataPeriod
    {
        public Guid Id { get; set; }
        public Guid ProjectCostingDataId { get; set; }
        public double Amount { get; set; }
        public double Quarter { get; set; }
        public double Year { get; set; }
    }
}
