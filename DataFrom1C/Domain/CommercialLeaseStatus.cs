using System.ComponentModel.DataAnnotations;

namespace DataFrom1C.Domain
{
    public class CommercialLeaseStatus
    {
        [Key]
        public Guid Id { get; set; }
        public string CommercialLeaseStatusId { get; set; }
        public string ContractId { get; set; }
        public string ServiceId { get; set; }
        public string CommercialLeaseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}
