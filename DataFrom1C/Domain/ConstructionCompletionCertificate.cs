using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class ConstructionCompletionCertificate
    {
        [Key]
        public Guid RowId { get; set; }
        public string ContractId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
