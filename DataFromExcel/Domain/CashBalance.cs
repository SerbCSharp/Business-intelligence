using System.ComponentModel.DataAnnotations;

namespace DataFromExcel.Domain
{
    public class CashBalance
    {
        [Key]
        public string Id { get; set; }
        public string Company { get; set; }
        public decimal Amount { get; set; }
    }
}
