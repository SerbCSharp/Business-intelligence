using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("DimDates", Schema = "params")]
    public class Date
    {
        [Key]
        public int Id { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }
    }
}
