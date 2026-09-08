namespace Reports.Domain
{
    public class ProjectCostingData
    {
        public Guid Id { get; set; }
        public string ComplexProperty { get; set; }
        public string Name { get; set; }
        public double Fact { get; set; }
        public string Field { get; set; }
        public List<ProjectCostingDataPeriod> ProjectCostingDataPeriods { get; set; } = [];
    }
}
