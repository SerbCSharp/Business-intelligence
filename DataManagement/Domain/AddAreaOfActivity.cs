namespace DataManagement.Domain
{
    public class AddAreaOfActivity
    {
        public string DocumentId { get; set; }
        public decimal Percent { get; set; }
        public string TypeOfActivity { get; set; }
        public string AreaOfActivity { get; set; }
        public bool DirectOrIndirect { get; set; }

        public DateTime Date { get; set; }
        public string Property { get; set; }
        public string CostItem { get; set; }
        public string TypeOperation { get; set; }
        public string Contractor { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string PaymentPurpose { get; set; }
    }
}
