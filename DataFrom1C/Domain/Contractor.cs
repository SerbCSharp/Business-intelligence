using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class Contractor
    {
        [Key]
        public Guid Id { get; set; }
        public string ContractorId { get; set; }
        public string Name { get; set; }
        public string CompanyId { get; set; }
    }
}
