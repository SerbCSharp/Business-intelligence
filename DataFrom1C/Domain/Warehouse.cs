using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class Warehouse
    {
        [Key]
        public Guid Id { get; set; }
        public string WarehouseId { get; set; }
        public string Name { get; set; }
        public string CompanyId { get; set; }
    }
}
