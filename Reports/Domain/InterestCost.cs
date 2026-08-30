using OfficeOpenXml.Attributes;

namespace Reports.Domain
{
    public class InterestCost
    {
        [EpplusTableColumn(Header = "Показатель")]
        public string Name { get; set; }

        [EpplusTableColumn(Header = "Затраты(факт)", NumberFormat = "### ### ### ##0.00")]
        public decimal IncurredCosts { get; set; }

        [EpplusTableColumn(Header = "Год", NumberFormat = "###0")]
        public int Year { get; set; }

        [EpplusTableColumn(Header = "Квартал", NumberFormat = "###0")]
        public int Quarter { get; set; }
        public int LineNumber { get; set; }
        public string Field { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalCost { get; set; }
        public decimal PercentageOfCosts { get; set; }
        public decimal PercentageOfCostsByPeriods { get; set; }

        [EpplusTableColumn(Header = "Сдача в эксплуатацию")]
        public bool CommissioningOfResidentialProperty { get; set; }
    }
}
