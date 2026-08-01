using System.ComponentModel.DataAnnotations;

namespace DataFromExcel.Domain
{
    public class ObjectOfSaleInPurchasePayment
    {
        [Key]
        public string DocumentId { get; set; }
        public string ContractId { get; set; }
        public string Property { get; set; }
        public string CostItem { get; set; }
        public string ComplexProperty { get; set; }
    }
}
