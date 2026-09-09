using OfficeOpenXml.Attributes;

namespace Reports.Application.DTO
{
    public class InterestCostDTO
    {
        [EpplusTableColumn(Header = "Год", NumberFormat = "###0")]
        public double Year { get; set; }

        [EpplusTableColumn(Header = "Квартал", NumberFormat = "###0")]
        public double Quarter { get; set; }

        [EpplusTableColumn(Header = "Наполнение Эскроу-счетов (после погашения)", NumberFormat = "### ### ### ##0.00")]
        public double EscrowFunding { get; set; }

        [EpplusTableColumn(Header = "Проценты к уплате", NumberFormat = "### ### ### ##0.00")]
        public double InterestPayable { get; set; }

        [EpplusTableColumn(Header = "Погашено процентов", NumberFormat = "### ### ### ##0.00")]
        public double InterestPaid { get; set; }

        [EpplusTableColumn(Header = "Неоплаченные проценты", NumberFormat = "### ### ### ##0.00")]
        public double UnpaidInterest { get; set; }

        [EpplusTableColumn(Header = "Сумма кредита", NumberFormat = "### ### ### ##0.00")]
        public double Principal { get; set; }

        [EpplusTableColumn(Header = "Погашено ОД", NumberFormat = "### ### ### ##0.00")]
        public double LoanRepayment { get; set; }

        [EpplusTableColumn(Header = "Остаток ОД", NumberFormat = "### ### ### ##0.00")]
        public double PrincipalBalance { get; set; }

        [EpplusTableColumn(Header = "Вся задолженность по кредиту", NumberFormat = "### ### ### ##0.00")]
        public double TotalPayoffAmount { get; set; }

        [EpplusTableColumn(Header = "К1", NumberFormat = "##0.0000")]
        public double ProportionOfDebtK1 { get; set; }

        [EpplusTableColumn(Header = "К2", NumberFormat = "##0.0000")]
        public double ProportionOfDebtK2 { get; set; }

        [EpplusTableColumn(Header = "К3", NumberFormat = "##0.0000")]
        public double ProportionOfCashK3 { get; set; }

        [EpplusTableColumn(Header = "К3 (условие)", NumberFormat = "### ### ### ##0.00")]
        public double ConditionK3 { get; set; }

        [EpplusTableColumn(Header = "Ключевая ставка", NumberFormat = "##0.0000")]
        public double KeyRate { get; set; }

        [EpplusTableColumn(Header = "ФОРср", NumberFormat = "##0.0000")]
        public double WeightedAverage { get; set; }

        [EpplusTableColumn(Header = "СТССВср", NumberFormat = "##0.0000")]
        public double BaseAssessmentRate { get; set; }

        [EpplusTableColumn(Header = "СтКрСпец", NumberFormat = "##0.0000")]
        public double SpecialCreditRate { get; set; }

        [EpplusTableColumn(Header = "СтКрБаз", NumberFormat = "##0.0000")]
        public double BaseLendingRate { get; set; }

        [EpplusTableColumn(Header = "СтСК", NumberFormat = "##0.0000")]
        public double DiscountRate { get; set; }

        [EpplusTableColumn(Header = "СтКрРасч", NumberFormat = "### ### ### ##0.00")]
        public double CalculatedInterestRate { get; set; }

        [EpplusTableColumn(Header = "СтКрТек", NumberFormat = "##0.0000")]
        public double CurrentInterestRate { get; set; }

        [EpplusTableColumn(Header = "Начислено процентов", NumberFormat = "### ### ### ##0.00")]
        public double AccruedInterest { get; set; }

        [EpplusIgnore]
        public double TotalCost { get; set; }

        [EpplusIgnore]
        public double TotalSales { get; set; }

        [EpplusIgnore]
        public bool CommissioningOfResidentialProperty { get; set; }
    }
}
