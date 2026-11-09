using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }
        public string PaymentId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public DateTime Date { get; set; }
        public string PaymentPurpose { get; set; }
        public string TypeOperation { get; set; }
        public string ContractId { get; set; }
        public string CashFlowItemId { get; set; }
        public string CompanyId { get; set; }
    }
}
