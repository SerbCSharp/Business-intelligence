using OfficeOpenXml.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("SalesValueByPeriods", Schema = "params")]
    public class SalesValueByPeriod
    {
        [Key]
        [EpplusIgnore]
        public Guid RowId { get; set; }

        [EpplusTableColumn(Header = "Комплекс")]
        public string ComplexProperty { get; set; }

        [EpplusTableColumn(Header = "Категория жилья")]
        public string Category { get; set; }

        [EpplusTableColumn(Header = "Плановые продажи за м2", NumberFormat = "### ### ### ##0.00")]
        public double SalesTargetInSqm { get; set; }

        [EpplusTableColumn(Header = "Квартал", NumberFormat = "###0")]
        public double Quarter { get; set; }

        [EpplusTableColumn(Header = "Год", NumberFormat = "###0")]
        public double Year { get; set; }
    }
}
