using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class CashFlowItem
    {
        [Key]
        public Guid Id { get; set; }
        public string CashFlowItemId { get; set; }
        public string Name { get; set; }
        public string CompanyId { get; set; }
    }
}
