using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("ReportStructures", Schema = "params")]
    public class ReportStructure
    {
        [Key]
        public Guid Id { get; set; }
        public string Field { get; set; }
        public string Name { get; set; }
        public string ReportSheet { get; set; }
        public int LineNumber { get; set; }
        public bool Parameter { get; set; }
        public string Formula { get; set; }
    }
}
