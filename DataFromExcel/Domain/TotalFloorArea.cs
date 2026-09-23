using System.ComponentModel.DataAnnotations;

namespace DataFromExcel.Domain
{
    public class TotalFloorArea
    {
        [Key]
        public Guid Id { get; set; }
        public decimal TotalArea { get; set; }
        public decimal ApartmentArea { get; set; }
        public string Property { get; set; }
    }
}
