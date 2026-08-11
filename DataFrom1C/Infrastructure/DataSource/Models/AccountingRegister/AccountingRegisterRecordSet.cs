using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.AccountingRegister
{
    public class AccountingRegisterRecordSet
    {
        [JsonPropertyName("Period")]
        public DateTime Date { get; set; }

        [JsonPropertyName("Содержание")]
        public string Name { get; set; }

        [JsonPropertyName("AccountDr_Key")]
        public string AccountDebitId { get; set; }

        [JsonPropertyName("AccountCr_Key")]
        public string AccountCreditId { get; set; }

        [JsonPropertyName("Сумма")]
        public decimal Amount { get; set; }
        public bool Active { get; set; }
    }
}
