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
        public string ReportSheet { get; set; }
        public string Field { get; set; }
        public bool Parameter { get; set; }
        public string ConstructionCostForecast { get; set; }
    }
}
