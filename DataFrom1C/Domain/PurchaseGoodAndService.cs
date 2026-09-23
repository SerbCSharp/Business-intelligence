using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class PurchaseGoodAndService
    {
        [Key]
        public Guid Id { get; set; }
        public string DocumentId { get; set; }
        public string ProductAndServiceId { get; set; }
        public string UnitId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
    }
}
