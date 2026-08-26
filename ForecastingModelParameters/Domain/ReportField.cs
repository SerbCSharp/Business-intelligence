using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("ReportFields", Schema = "params")]
    public class ReportField
    {
        [Key]
        public Guid RowId { get; set; }
        public string Name { get; set; }
        public int LineNumber { get; set; }
        public bool FixedOrPercentage { get; set; }
    }
}
