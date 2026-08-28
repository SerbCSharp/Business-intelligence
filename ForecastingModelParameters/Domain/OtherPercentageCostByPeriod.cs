using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("OtherPercentageCostByPeriods", Schema = "params")]
    public class OtherPercentageCostByPeriod
    {
        [Key]
        [EpplusIgnore]
        public Guid RowId { get; set; }

        [EpplusTableColumn(Header = "Комплекс")]
        public string ComplexProperty { get; set; }

        [EpplusTableColumn(Header = "Показатель")]
        public string Name { get; set; }

        [Precision(18, 4)]
        [EpplusTableColumn(Header = "Процент", NumberFormat = "##0.0000")]
        public double PercentageOfCosts { get; set; }

        [EpplusTableColumn(Header = "Квартал", NumberFormat = "###0")]
        public double Quarter { get; set; }

        [EpplusTableColumn(Header = "Год", NumberFormat = "###0")]
        public double Year { get; set; }

        [EpplusTableColumn(Hidden = true)]
        public string Field { get; set; }
    }
}
