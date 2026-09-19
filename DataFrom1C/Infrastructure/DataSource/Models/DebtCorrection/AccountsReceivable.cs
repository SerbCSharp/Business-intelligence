using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.DebtCorrection
{
    public class AccountsReceivable
    {
        [JsonPropertyName("ДоговорКонтрагента_Key")]
        public string ContractId { get; set; }

        [JsonPropertyName("КорДоговорКонтрагента_Key")]
        public string CorContractId { get; set; }

        [JsonPropertyName("Сумма")]
        public decimal Amount { get; set; }
    }
}
