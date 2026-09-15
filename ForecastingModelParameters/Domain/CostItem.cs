using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("DimCostItems", Schema = "params")]
    public class CostItem
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool FlowDirection { get; set; } // true - доход
        public string NameGroup { get; set; }

        public Guid ProjectForecastId { get; set; }
        public ProjectForecast ProjectForecast { get; set; }
    }
}
