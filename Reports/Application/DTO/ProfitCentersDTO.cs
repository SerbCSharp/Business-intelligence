namespace Reports.Application.DTO
{
    public class ProfitCentersDTO
    {
        public string TypeOfActivity { get; set; }
        public string AreaOfActivity { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal IndirectCost { get; set; }
    }
}
