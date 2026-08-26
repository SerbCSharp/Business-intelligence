using OfficeOpenXml.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ForecastingModelParameters.Domain
{
    [Table("OtherFixedCostByPeriods", Schema = "params")]
    public class OtherFixedCostByPeriod
    {
        [Key]
        //[EpplusTableColumn(Hidden = true)]
        [JsonIgnore]
        public Guid RowId { get; set; }

        [EpplusTableColumn(Header = "Комплекс")]
        public string ComplexProperty { get; set; }

        [EpplusTableColumn(Header = "Показатель")]
        public string Name { get; set; }

        [EpplusTableColumn(Header = "Плановые затраты", NumberFormat = "### ### ### ##0.00")]
        public double Amount { get; set; }

        [EpplusTableColumn(Header = "Квартал", NumberFormat = "###0")]
        public double Quarter { get; set; }

        [EpplusTableColumn(Header = "Год", NumberFormat = "###0")]
        public double Year { get; set; }
    }
}
