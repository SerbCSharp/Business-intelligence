using OfficeOpenXml.Attributes;
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
        public double PricePerSqm { get; set; }
        public double SquareMeters { get; set; }
        public double Sold { get; set; }

        [EpplusTableColumn(Header = "Признак для БПВ и КВ", NumberFormat = "General")]
        public bool ResidentialProperty { get; set; }
    }
}
