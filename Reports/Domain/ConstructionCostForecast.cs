using OfficeOpenXml.Attributes;

namespace Reports.Domain
{
    public class ConstructionCostForecast
    {
        [EpplusTableColumn(Header = "Наименование")]
        public string Name { get; set; }

        [EpplusTableColumn(Header = "Прогноз", NumberFormat = "### ### ### ##0.00")]
        public decimal Amount { get; set; }

        [EpplusIgnore]
        public string Field { get; set; }
    }
}
