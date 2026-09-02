using OfficeOpenXml.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("ConstructionCostByProperties", Schema = "params")]
    public class ConstructionCostByProperty
    {
        [Key]
        [EpplusIgnore]
        public Guid RowId { get; set; }

        [EpplusTableColumn(Header = "Комплекс")]
        public string ComplexProperty { get; set; }

        [EpplusTableColumn(Header = "Позиция")]
        public string Property { get; set; }

        [EpplusTableColumn(Header = "Стоимость строительства за м2", NumberFormat = "### ### ### ##0.00")]
        public double PlannedCostPerSqm { get; set; }

        [EpplusTableColumn(Header = "Количество м2", NumberFormat = "### ### ### ##0.00")]
        public double SquareMeters { get; set; }

        [EpplusTableColumn(Header = "Затраты(факт)", NumberFormat = "### ### ### ##0.00")]
        public double IncurredCosts { get; set; }
    }
}
