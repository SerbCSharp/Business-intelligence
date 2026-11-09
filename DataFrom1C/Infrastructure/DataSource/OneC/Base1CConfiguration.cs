namespace DataFrom1C.Infrastructure.DataSource.OneC
{
    public class Base1CConfiguration
    {
        public const string Section = "Base1CConfiguration";
        public string Username { get; set; }
        public string Password { get; set; }
        public string ApiUrl { get; set; }
        public string CompanyId { get; set; }
    }
}
