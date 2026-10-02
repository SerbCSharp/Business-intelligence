using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class Company
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
