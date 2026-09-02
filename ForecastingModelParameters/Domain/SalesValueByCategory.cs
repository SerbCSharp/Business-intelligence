using OfficeOpenXml.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("SalesValueByCategories", Schema = "params")]
    public class SalesValueByCategory
    {
        [Key]
        [EpplusIgnore]
        public Guid RowId { get; set; }

        [EpplusTableColumn(Header = "Комплекс")]
        public string ComplexProperty { get; set; }

        [EpplusTableColumn(Header = "Категория жилья")]
        public string Category { get; set; }

        [EpplusTableColumn(Header = "Цена продаж за м2", NumberFormat = "### ### ### ##0.00")]
        public double PricePerSqm { get; set; }

        [EpplusTableColumn(Header = "Количество м2", NumberFormat = "### ### ### ##0.00")]
        public double SquareMeters { get; set; }

        [EpplusTableColumn(Header = "Продано м2", NumberFormat = "### ### ### ##0.00")]
        public double Sold { get; set; }

        [EpplusTableColumn(Header = "Признак для БПВ и КВ", NumberFormat = "General")]
        public bool ResidentialProperty { get; set; }
    }
}
