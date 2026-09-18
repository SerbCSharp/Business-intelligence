using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("ReportLines", Schema = "params")]
    public class ReportLine
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ReportSheet { get; set; }
        public int LineNumber { get; set; }
        public string LineType { get; set; } // Input or Formula
        public string FormulaExpression { get; set; }
    }
}
