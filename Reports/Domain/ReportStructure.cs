namespace Reports.Domain
{
    public class ReportStructure
    {
        public string Field { get; set; }
        public string Name { get; set; }
        public string ReportSheet { get; set; }
        public int LineNumber { get; set; }
        public bool Parameter { get; set; }
        public string Formula { get; set; }
    }
}
