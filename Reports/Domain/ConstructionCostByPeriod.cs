using OfficeOpenXml.Attributes;

namespace Reports.Domain
{
    public class ConstructionCostByPeriod
    {
        [EpplusTableColumn(Header = "Позиция")]
        public string Property { get; set; }

        [EpplusTableColumn(Header = "Площадь", NumberFormat = "### ### ### ##0.00")]
        public decimal SquareMeters { get; set; }

        [EpplusTableColumn(Header = "Бюджет", NumberFormat = "### ### ### ##0.00")]
        public decimal PlannedCost { get; set; }

        [EpplusTableColumn(Header = "Затраты(факт)", NumberFormat = "### ### ### ##0.00")]
        public decimal IncurredCosts { get; set; }

        [EpplusTableColumn(Header = "Остаток", NumberFormat = "### ### ### ##0.00")]
        public decimal Remaining { get; set; }

        [EpplusTableColumn(Header = "Год", NumberFormat = "###0")]
        public int Year { get; set; }

        [EpplusTableColumn(Header = "Квартал", NumberFormat = "###0")]
        public int Quarter { get; set; }

        [EpplusTableColumn(Header = "Плановые затраты", NumberFormat = "### ### ### ##0.00")]
        public decimal ConstructionCost { get; set; }

        [EpplusTableColumn(Header = "Сдача в эксплуатацию")]
        public bool CommissioningOfResidentialProperty { get; set; }
    }
}
