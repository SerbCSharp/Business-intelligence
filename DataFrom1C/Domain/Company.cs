using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }
        public string OrganizationId { get; set; }
        public string Name { get; set; }
        public string CompanyId { get; set; }
    }
}
