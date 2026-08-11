using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.AccountingRegister
{
    public class AccountingRegisterValue
    {
        [JsonPropertyName("RecordSet")]
        public AccountingRegisterRecordSet[] RecordSet { get; set; }
    }
}
