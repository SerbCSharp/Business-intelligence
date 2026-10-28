using OfficeOpenXml.Attributes;

namespace Reports.Domain
{
    public class CostSurface
    {
        [EpplusTableColumn(Header = "Оплата", NumberFormat = "### ### ### ##0.00")]
        public decimal Amount { get; set; }
        public string Property { get; set; }
        public string CostItem { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}
