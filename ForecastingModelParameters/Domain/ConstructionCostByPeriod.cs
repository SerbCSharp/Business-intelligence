using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("ConstructionCostByPeriods", Schema = "params")]
    public class ConstructionCostByPeriod
    {
        [Key]
        [EpplusIgnore]
        public Guid RowId { get; set; }

        [EpplusTableColumn(Header = "Комплекс")]
        public string ComplexProperty { get; set; }

        [EpplusTableColumn(Header = "Позиция")]
        public string Property { get; set; }

        [EpplusTableColumn(Header = "Стоимость строительства", NumberFormat = "### ### ### ##0.00")]
        public double ConstructionCost { get; set; }

        [Precision(18, 4)]
        [EpplusTableColumn(Header = "Процент", NumberFormat = "##0.0000")]
        public double PercentageOfCosts { get; set; }

        [EpplusTableColumn(Header = "Сдача в эксплуатацию")]
        public bool CommissioningOfResidentialProperty { get; set; }

        [EpplusTableColumn(Header = "Квартал", NumberFormat = "###0")]
        public double Quarter { get; set; }

        [EpplusTableColumn(Header = "Год", NumberFormat = "###0")]
        public double Year { get; set; }
    }
}
