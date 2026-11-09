namespace DataFrom1C.Domain
{
    public class CommercialLease
    {
        public Guid Id { get; set; }
        public string CommercialLeaseId { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }
        public string PropertyTypeId { get; set; }
        public string CompanyId { get; set; }
    }
}
