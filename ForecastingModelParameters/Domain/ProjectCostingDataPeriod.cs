using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("ProjectCostingDataPeriods", Schema = "params")]
    public class ProjectCostingDataPeriod
    {
        public Guid Id { get; set; }
        public Guid ProjectCostingDataId { get; set; }
        public double Amount { get; set; }
        public double Quarter { get; set; }
        public double Year { get; set; }
        public ProjectCostingData ProjectCostingData { get; set; }
    }
}
