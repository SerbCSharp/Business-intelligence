using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class Unit
    {
        [Key]
        public Guid Id { get; set; }
        public string UnitId { get; set; }
        public string Name { get; set; }
        public string CompanyId { get; set; }
    }
}
