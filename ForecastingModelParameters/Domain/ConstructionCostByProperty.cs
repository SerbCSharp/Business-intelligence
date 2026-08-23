using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("ConstructionCostByProperties", Schema = "params")]
    public class ConstructionCostByProperty
    {
        [Key]
        public Guid RowId { get; set; }
        public string ComplexProperty { get; set; }
        public string Property { get; set; }
        public decimal PlannedCostPerSqm { get; set; }
        public decimal SquareMeters { get; set; }
        public decimal IncurredCosts { get; set; }
    }
}
