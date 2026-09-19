using System.ComponentModel.DataAnnotations;

namespace DataFromExcel.Domain
{
    public class AccountingTransaction
    {
        [Key]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string ContractId { get; set; }
    }
}
