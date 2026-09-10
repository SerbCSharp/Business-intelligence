using OfficeOpenXml.Attributes;

namespace Reports.Application.DTO
{
    public class ConstructionCostForecastDTO
    {
        [EpplusTableColumn(Header = "Наименование")]
        public string Name { get; set; }

        [EpplusTableColumn(Header = "Прогноз", NumberFormat = "### ### ### ##0.00")]
        public decimal Amount { get; set; }

        [EpplusIgnore]
        public string Field { get; set; }
    }
}
