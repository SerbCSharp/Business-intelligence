using OfficeOpenXml.Attributes;

namespace Reports.Domain
{
    public class ReconciliationStatement
    {
        [EpplusTableColumn(Header = "Контрагент")]
        public string Contractor { get; set; }

        [EpplusTableColumn(Header = "Договор")]
        public string Contract { get; set; }

        [EpplusTableColumn(Header = "Выполнение", NumberFormat = "### ### ### ##0.00")]
        public decimal Debit { get; set; }

        [EpplusTableColumn(Header = "Оплата", NumberFormat = "### ### ### ##0.00")]
        public decimal Credit { get; set; }

        [EpplusTableColumn(Header = "Разность", NumberFormat = "### ### ### ##0.00")]
        public decimal Difference { get; set; }
    }
}
