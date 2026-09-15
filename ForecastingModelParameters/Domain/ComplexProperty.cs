using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("DimComplexProperties", Schema = "params")]
    public class ComplexProperty
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid ProjectForecastId { get; set; }
        public ProjectForecast ProjectForecast { get; set; }
    }
}
