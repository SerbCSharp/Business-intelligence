using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("ProjectCostingDatas", Schema = "params")]
    public class ProjectCostingData
    {
        [Key]
        public Guid Id { get; set; }
        public string ComplexProperty { get; set; }
        public string Name { get; set; }
        public double Fact { get; set; }
        public string Field { get; set; }
        public List<ProjectCostingDataPeriod> ProjectCostingDataPeriods { get; set; } = [];
    }
}
