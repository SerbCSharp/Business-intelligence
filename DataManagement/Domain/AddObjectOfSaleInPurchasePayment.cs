namespace DataManagement.Domain
{
    public class AddObjectOfSaleInPurchasePayment
    {
        public string Id { get; set; }
        public string ContractId { get; set; }
        public string Property { get; set; }
        public string CostItem { get; set; }
        public string CashFlowItem { get; set; }
        public string Contractor { get; set; }
        public DateTime Date { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string PaymentPurpose { get; set; }
    }
}
