using System.ComponentModel.DataAnnotations;

namespace DataFromExcel.Domain
{
    public class AreaOfActivityPayment
    {
        [Key]
        public string DocumentId { get; set; }
        public decimal Percent { get; set; }
        public string TypeOfActivity { get; set; }
        public string AreaOfActivity { get; set; }
        public bool DirectOrIndirect { get; set; }
        public string ContractIdIncome { get; set; }
    }
}
