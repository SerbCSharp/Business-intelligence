using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("SalesValueByPeriods", Schema = "params")]
    public class SalesValueByPeriod
    {
        [Key]
        public Guid RowId { get; set; }
        public string ComplexProperty { get; set; }
        public string Category { get; set; }
        public decimal SalesValue { get; set; }
        public int Quarter { get; set; }
        public int Year { get; set; }
    }
}
