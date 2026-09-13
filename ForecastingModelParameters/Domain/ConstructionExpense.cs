using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("ConstructionExpenses", Schema = "params")]
    public class ConstructionExpense
    {
        [Key]
        public Guid Id { get; set; }
        public string ComplexProperty { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Property { get; set; }
        public string CostItem { get; set; }
        public string Field { get; set; }
    }
}
