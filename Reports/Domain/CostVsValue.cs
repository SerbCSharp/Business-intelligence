namespace Reports.Domain
{
    public class CostVsValue
    {
        public decimal PaymentsAmount { get; set; }
        public decimal InvoicesAmount { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string ComplexProperty { get; set; }
    }
}
