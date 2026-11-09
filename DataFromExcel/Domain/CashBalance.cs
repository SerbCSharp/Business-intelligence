using System.ComponentModel.DataAnnotations;

namespace DataFromExcel.Domain
{
    public class CashBalance
    {
        [Key]
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public decimal Amount { get; set; }
        public bool IsSelected { get; set; }
    }
}
