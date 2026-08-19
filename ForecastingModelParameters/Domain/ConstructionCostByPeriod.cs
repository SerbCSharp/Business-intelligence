using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("ConstructionCostByPeriods", Schema = "params")]
    public class ConstructionCostByPeriod
    {
        [Key]
        public Guid RowId { get; set; }
        public string ComplexProperty { get; set; }
        public string Property { get; set; }
        public decimal ConstructionCost { get; set; }
        public decimal PercentageOfCosts { get; set; }
        public int Quarter { get; set; }
        public int Year { get; set; }
    }
}
