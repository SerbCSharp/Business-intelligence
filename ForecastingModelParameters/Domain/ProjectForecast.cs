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
        public int DateId { get; set; }
        public int ComplexPropertyId { get; set; }
        public int PropertyId { get; set; }
        public int CostItemId { get; set; }
        public int LoanTermId { get; set; }
    }
}
