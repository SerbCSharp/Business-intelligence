using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("OtherCostByPeriods", Schema = "params")]
    public class OtherCostByPeriod
    {
        [Key]
        public Guid RowId { get; set; }
        public string ComplexProperty { get; set; }
        public string Name { get; set; }
        public string Sheet { get; set; }
        public decimal MoneyOut { get; set; }
        public decimal MoneyIn { get; set; }
        public int Quarter { get; set; }
        public int Year { get; set; }
    }
}
