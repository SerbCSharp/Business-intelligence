using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("DimDates", Schema = "params")]
    public class Date
    {
        [Key]
        public Guid Id { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }

        public Guid ProjectForecastId { get; set; }
        public ProjectForecast ProjectForecast { get; set; }
    }
}
