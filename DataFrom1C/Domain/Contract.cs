using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class Contract
    {
        [Key]
        public string ContractId { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string ContractorId { get; set; }
        public string CodeContract { get; set; }
    }
}
