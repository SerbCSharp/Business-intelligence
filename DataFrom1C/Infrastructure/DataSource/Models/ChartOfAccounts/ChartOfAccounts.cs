using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.ChartOfAccounts
{
    public class ChartOfAccounts
    {
        [JsonPropertyName("value")]
        public ChartOfAccountsValue[] Value { get; set; }
    }
}
