using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class AccountingEntry
    {
        [Key]
        public Guid RowId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string AccountDebitId { get; set; }
        public string AccountCreditId { get; set; }
        public decimal Amount { get; set; }
    }
}
