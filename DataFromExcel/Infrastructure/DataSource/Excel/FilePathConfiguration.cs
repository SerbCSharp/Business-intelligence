namespace DataFromExcel.Infrastructure.DataSource.Excel
{
    public class FilePathConfiguration
    {
        public const string Section = "FileSettings";
        public string FilePath { get; set; }
        public string CompanyId { get; set; }
    }
}
