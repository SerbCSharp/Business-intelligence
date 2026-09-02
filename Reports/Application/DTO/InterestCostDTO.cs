using OfficeOpenXml.Attributes;

namespace Reports.Application.DTO
{
    public class InterestCostDTO
    {
        [EpplusTableColumn(Header = "Год", NumberFormat = "###0")]
        public int Year { get; set; }

        [EpplusTableColumn(Header = "Квартал", NumberFormat = "###0")]
        public int Quarter { get; set; }

        //[EpplusIgnore]
        public decimal TotalSales { get; set; }

        //[EpplusIgnore]
        public decimal TotalCost { get; set; }

        [EpplusTableColumn(Header = "Наполнение Эскроу-счетов (после погашения)", NumberFormat = "### ### ### ##0.00")]
        public decimal EscrowFunding { get; set; }

        [EpplusTableColumn(Header = "Проценты к уплате", NumberFormat = "### ### ### ##0.00")]
        public decimal InterestPayable { get; set; }

        [EpplusTableColumn(Header = "Погашено процентов", NumberFormat = "### ### ### ##0.00")]
        public decimal InterestPaid { get; set; }

        [EpplusTableColumn(Header = "Неоплаченные проценты", NumberFormat = "### ### ### ##0.00")]
        public decimal UnpaidInterest { get; set; }

        [EpplusTableColumn(Header = "Сумма кредита", NumberFormat = "### ### ### ##0.00")]
        public decimal Principal { get; set; }

        [EpplusTableColumn(Header = "Погашено ОД", NumberFormat = "### ### ### ##0.00")]
        public decimal LoanRepayment { get; set; }

        [EpplusTableColumn(Header = "Остаток ОД", NumberFormat = "### ### ### ##0.00")]
        public decimal PrincipalBalance { get; set; }

        [EpplusTableColumn(Header = "Вся задолженность по кредиту", NumberFormat = "### ### ### ##0.00")]
        public decimal TotalPayoffAmount { get; set; }

        [EpplusTableColumn(Header = "К1", NumberFormat = "##0.0000")]
        public decimal ProportionOfDebtK1 { get; set; }

        [EpplusTableColumn(Header = "К2", NumberFormat = "##0.0000")]
        public decimal ProportionOfDebtK2 { get; set; }

        [EpplusTableColumn(Header = "К3", NumberFormat = "##0.0000")]
        public decimal ProportionOfCashK3 { get; set; }

        [EpplusTableColumn(Header = "К3 (условие)", NumberFormat = "### ### ### ##0.00")]
        public decimal ConditionK3 { get; set; }

        [EpplusTableColumn(Header = "Ключевая ставка", NumberFormat = "##0.0000")]
        public decimal KeyRate { get; set; }

        [EpplusTableColumn(Header = "ФОРср", NumberFormat = "##0.0000")]
        public decimal WeightedAverage { get; set; }

        [EpplusTableColumn(Header = "СТССВср", NumberFormat = "##0.0000")]
        public decimal BaseAssessmentRate { get; set; }

        [EpplusTableColumn(Header = "СтКрСпец", NumberFormat = "##0.0000")]
        public decimal SpecialCreditRate { get; set; }

        [EpplusTableColumn(Header = "СтКрБаз", NumberFormat = "##0.0000")]
        public decimal BaseLendingRate { get; set; }

        [EpplusTableColumn(Header = "СтСК", NumberFormat = "##0.0000")]
        public decimal DiscountRate { get; set; }

        [EpplusTableColumn(Header = "СтКрРасч", NumberFormat = "### ### ### ##0.00")]
        public decimal CalculatedInterestRate { get; set; }

        [EpplusTableColumn(Header = "СтКрТек", NumberFormat = "##0.0000")]
        public decimal CurrentInterestRate { get; set; }

        [EpplusTableColumn(Header = "Начислено процентов", NumberFormat = "### ### ### ##0.00")]
        public decimal AccruedInterest { get; set; }

        [EpplusIgnore]
        public bool CommissioningOfResidentialProperty { get; set; }
    }
}
