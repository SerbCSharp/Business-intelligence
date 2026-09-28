using OfficeOpenXml.Attributes;

namespace Reports.Domain
{
    public class CashFlowFromRentalOperations
    {
        public string CashFlowItems { get; set; }
        public string TypeOperation { get; set; }

        [EpplusTableColumn(Header = "Дата", NumberFormat = "dd.mm.yyyy")]
        public DateTime Date { get; set; }

        [EpplusTableColumn(Header = "Доходы", NumberFormat = "### ### ### ##0.00")]
        public decimal Credit { get; set; }

        [EpplusTableColumn(Header = "Расходы", NumberFormat = "### ### ### ##0.00")]
        public decimal Debit { get; set; }

        [EpplusTableColumn(Header = "Договор")]
        public string Contract { get; set; }

        [EpplusTableColumn(Header = "Контрагент")]
        public string Contractor { get; set; }

        [EpplusTableColumn(Header = "Назначение платежа")]
        public string PaymentPurpose { get; set; }
    }
}
