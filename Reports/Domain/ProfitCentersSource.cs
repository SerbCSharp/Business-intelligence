namespace Reports.Domain
{
    public class ProfitCentersSource
    {
        public DateTime Date { get; set; }
        public string TypeOfActivity { get; set; }
        public string AreaOfActivity { get; set; }
        public string TypeOperation { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Percent { get; set; }
        public bool DirectOrIndirect { get; set; }
        public string PaymentPurpose { get; set; }
        public string Number { get; set; }
        public string Contractor { get; set; }
    }
}
