using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("FactProjectForecasts", Schema = "params")]
    public class ProjectForecast
    {
        [Key]
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public string DateId { get; set; }
        public string ComplexPropertyId { get; set; }
        public string CostItemId { get; set; }
        public string PropertyId { get; set; }
    }
}
