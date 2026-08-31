namespace Reports.Application.DTO
{
    public class ConstructionCostDTO
    {
        public string Contractor { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal ContractAmount { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal PaymentAmount { get; set; }
        public string Property { get; set; }
        public string CostItem { get; set; }
        public decimal ConstructionCost { get; set; }
        public decimal ConstructionCostPlusVATDifference { get; set; }
        public decimal GeneralContractorMarkup { get; set; }
        public string ContractorOrSupplier { get; set; }
        public decimal VATRate { get; set; }
    }
}
