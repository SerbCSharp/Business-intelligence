using OfficeOpenXml.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ForecastingModelParameters.Domain
{
    [Table("OtherFixedCosts", Schema = "params")]
    public class OtherFixedCost
    {
        [Key]
        //[EpplusTableColumn(Hidden = true)]
        [JsonIgnore]
        public Guid RowId { get; set; }

        [EpplusTableColumn(Header = "Комплекс")]
        public string ComplexProperty { get; set; }

        [EpplusTableColumn(Header = "Показатель")]
        public string Name { get; set; }

        [EpplusTableColumn(Header = "Затраты(факт)", NumberFormat = "### ### ### ##0.00")]
        public double IncurredCosts { get; set; }
    }
}
