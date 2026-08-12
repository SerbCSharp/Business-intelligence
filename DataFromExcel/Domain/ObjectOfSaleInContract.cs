using System.ComponentModel.DataAnnotations;

namespace DataFromExcel.Domain
{
    public class ObjectOfSaleInContract
    {
        [Key]
        public string ContractId { get; set; }
        public string Property { get; set; }
        public string CostItem { get; set; }
        public decimal Amount { get; set; }
        public string ComplexProperty { get; set; }
    }
}
