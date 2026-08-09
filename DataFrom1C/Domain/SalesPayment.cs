using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class SalesPayment
    {
        [Key]
        public string DocumentId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string ContractId { get; set; }
        public string PaymentPurpose { get; set; }
        public string CashFlowItemId { get; set; }
        public string TypeOperation { get; set; }
    }
}
