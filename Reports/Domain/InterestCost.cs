namespace Reports.Domain
{
    public class InterestCost
    {
        public int Year { get; set; }
        public int Quarter { get; set; }
        public string Name { get; set; }
        public string Field { get; set; }
        public decimal Fact { get; set; }
        public int LineNumber { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Amount { get; set; }
    }
}