using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class CostItem
    {
        [Key]
        public Guid Id { get; set; }
        public string CostItemId { get; set; }
        public string Name { get; set; }
        public string CompanyId { get; set; }
    }
}
