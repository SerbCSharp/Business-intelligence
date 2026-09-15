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
        public Guid DateId { get; set; }
        public Guid ComplexPropertyId { get; set; }
        public int PropertyId { get; set; }
        public Guid CostItemId { get; set; }
        public Guid LoanTermId { get; set; }

        public Date Date { get; set; }
        public ComplexProperty ComplexProperty { get; set; }
        public Property Property { get; set; }
        public CostItem CostItem { get; set; }
        public LoanTerm LoanTerm { get; set; }
    }
}
