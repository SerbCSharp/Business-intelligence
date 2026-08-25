using OfficeOpenXml.Attributes;

namespace Reports.Domain
{
    public class SalesTarget
    {
        [EpplusTableColumn(Header = "Категория")]
        public string Category { get; set; }

        [EpplusTableColumn(Header = "Площадь", NumberFormat = "### ### ### ##0.00")]
        public decimal SquareMeters { get; set; }

        [EpplusTableColumn(Header = "Цена за кв.м.", NumberFormat = "### ### ### ##0.00")]
        public decimal PricePerSqm { get; set; }

        [EpplusTableColumn(Header = "Продано(факт)", NumberFormat = "### ### ### ##0.00")]
        public decimal Sold { get; set; }

        [EpplusTableColumn(Header = "Остаток", NumberFormat = "### ### ### ##0.00")]
        public decimal Remaining { get; set; }

        [EpplusTableColumn(Header = "Год", NumberFormat = "###0")]
        public int Year { get; set; }

        [EpplusTableColumn(Header = "Квартал", NumberFormat = "###0")]
        public int Quarter { get; set; }

        [EpplusTableColumn(Header = "План продаж в кв.м.", NumberFormat = "### ### ### ##0.00")]
        public decimal SalesTargetInSqm { get; set; }

        [EpplusTableColumn(Header = "План продаж в руб.", NumberFormat = "### ### ### ##0.00")]
        public decimal SalesTargetInRub { get; set; }
    }
}
