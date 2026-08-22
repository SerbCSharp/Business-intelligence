using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("OtherCosts", Schema = "params")]
    public class OtherCost
    {
        [Key]
        public Guid RowId { get; set; }
        public string ComplexProperty { get; set; }
        public string Name { get; set; }
        public decimal IncurredCosts { get; set; }
    }
}
