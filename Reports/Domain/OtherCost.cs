using OfficeOpenXml.Attributes;

namespace Reports.Domain
{
    public class OtherCost
    {
        [EpplusTableColumn(Header = "Показатель")]
        public string Name { get; set; }

        [EpplusTableColumn(Header = "Затраты(факт)", NumberFormat = "### ### ### ##0.00")]
        public decimal IncurredCosts { get; set; }

        [EpplusTableColumn(Header = "Год", NumberFormat = "###0")]
        public int Year { get; set; }

        [EpplusTableColumn(Header = "Квартал", NumberFormat = "###0")]
        public int Quarter { get; set; }

        [EpplusTableColumn(Header = "Плановые затраты", NumberFormat = "### ### ### ##0.00")]
        public decimal Amount { get; set; }
    }
}
