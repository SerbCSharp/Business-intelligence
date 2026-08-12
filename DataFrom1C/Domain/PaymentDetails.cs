using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class PaymentDetails
    {
        [Key]
        public Guid RowId { get; set; }
        public string DocumentId { get; set; }
        public string ContractId { get; set; }
        public decimal Amount { get; set; }
        public string InvoiceId { get; set; }
        public decimal AmountVAT { get; set; }
    }
}
