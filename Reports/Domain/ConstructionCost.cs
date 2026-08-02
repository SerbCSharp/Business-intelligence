namespace Reports.Domain
{
    public class ConstructionCost
    {
        public string Contractor { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public decimal ContractAmount { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string Property { get; set; }
        public string CostItem { get; set; }
    }
}
