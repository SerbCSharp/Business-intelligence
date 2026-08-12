using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.DebitToCurrentAccount
{
    public class PaymentExplanation
    {
        public string Ref_Key { get; set; }

        [JsonPropertyName("ДоговорКонтрагента_Key")]
        public string ContractId { get; set; }

        [JsonPropertyName("СуммаПлатежа")]
        public decimal Amount { get; set; }

        [JsonPropertyName("СчетНаОплату_Key")]
        public string InvoiceId { get; set; }

        [JsonPropertyName("СуммаНДС")]
        public decimal AmountVAT { get; set; }
    }
}
