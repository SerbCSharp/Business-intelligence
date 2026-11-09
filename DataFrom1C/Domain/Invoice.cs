using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class Invoice
    {
        [Key]
        public Guid Id { get; set; }
        public string InvoiceId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public DateTime Date { get; set; }
        public string ContractId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyId { get; set; }
    }
}
