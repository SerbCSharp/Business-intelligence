using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class ProductAndService
    {
        [Key]
        public Guid Id { get; set; }
        public string ProductAndServiceId { get; set; }
        public string Name { get; set; }
        public string CompanyId { get; set; }
    }
}
