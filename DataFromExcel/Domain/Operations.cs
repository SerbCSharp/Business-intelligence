using System.ComponentModel.DataAnnotations;

namespace DataFromExcel.Domain
{
    public class Operations
    {
        [Key]
        public string OperationId { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string ContractDebit { get; set; }
        public string ContractCredit { get; set; }
    }
}
