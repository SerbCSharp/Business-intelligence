using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class Invoice
    {
        [Key]
        public string Id { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public DateTime Date { get; set; }
        public string ContractId { get; set; }
        public string WarehouseId { get; set; }
    }
}
