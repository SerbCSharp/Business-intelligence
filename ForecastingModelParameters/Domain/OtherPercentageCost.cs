using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ForecastingModelParameters.Domain
{
    [Table("OtherPercentageCosts", Schema = "params")]
    public class OtherPercentageCost
    {
        [Key]
        //[EpplusTableColumn(Hidden = true)]
        [JsonIgnore]
        public Guid RowId { get; set; }

        [EpplusTableColumn(Header = "Комплекс")]
        public string ComplexProperty { get; set; }

        [EpplusTableColumn(Header = "Показатель")]
        public string Name { get; set; }

        [Precision(18, 4)]
        [EpplusTableColumn(Header = "Процент", NumberFormat = "##0.0000")]
        public double PercentageOfCosts { get; set; }

        [EpplusTableColumn(Header = "Признак для БПВ и КВ", NumberFormat = "General")]
        public bool ResidentialProperty { get; set; }
    }
}
