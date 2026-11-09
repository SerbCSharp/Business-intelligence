using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class ProductGroup
    {
        [Key]
        public Guid Id { get; set; }
        public string ProductGroupId { get; set; }
        public string Name { get; set; }
        public string CompanyId { get; set; }
    }
}
