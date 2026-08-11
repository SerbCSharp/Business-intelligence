using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class Account
    {
        [Key]
        public string AccountId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
