using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("SalesValueByCategories", Schema = "params")]
    public class SalesValueByCategory
    {
        [Key]
        public Guid RowId { get; set; }
        public string ComplexProperty { get; set; }
        public string Category { get; set; }
        public decimal SalesValue { get; set; }
        public decimal Sold { get; set; }
    }
}
