namespace DataManagement.Domain
{
    public class AddObjectOfSaleInContract
    {
        public string ContractId { get; set; }
        public string Property { get; set; }
        public string CostItem { get; set; }
        public decimal Amount { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Contractor { get; set; }
        public int TotalContractId { get; set; }
        public string CodeContract { get; set; }
    }
}
