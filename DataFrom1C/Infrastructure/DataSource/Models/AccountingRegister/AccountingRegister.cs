using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.AccountingRegister
{
    public class AccountingRegister
    {
        [JsonPropertyName("value")]
        public AccountingRegisterValue[] Value { get; set; }
    }
}
