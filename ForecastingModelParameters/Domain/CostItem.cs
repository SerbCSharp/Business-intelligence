using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("DimCostItems", Schema = "params")]
    public class CostItem
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string FlowDirection { get; set; } // Inflow or Outflow
    }
}
