namespace Reports.Domain
{
    public class CostSurface
    {
        public string CostItem { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Amount { get; set; }
        public string Property { get; set; }
        public decimal TotalArea { get; set; }
    }
}
