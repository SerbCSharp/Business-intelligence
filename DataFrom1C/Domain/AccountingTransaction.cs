using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class AccountingTransaction
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string ContractId { get; set; }
    }
}
