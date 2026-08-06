using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.DebitToCurrentAccount
{
    public class DebitToCurrentAccountValue
    {
        [JsonPropertyName("Ref_Key")]
        public string DocumentId { get; set; }
        public DateTime Date { get; set; }

        [JsonPropertyName("СуммаДокумента")]
        public decimal Amount { get; set; }

        [JsonPropertyName("ДоговорКонтрагента_Key")]
        public string ContractId { get; set; }

        [JsonPropertyName("НазначениеПлатежа")]
        public string PaymentPurpose { get; set; }

        [JsonPropertyName("СтатьяДвиженияДенежныхСредств_Key")]
        public string CashFlowItemId { get; set; }

        [JsonPropertyName("РасшифровкаПлатежа")]
        public PaymentExplanation[] PaymentsExplanation { get; set; }

        [JsonPropertyName("ВидОперации")]
        public string TypeOperation { get; set; }
    }
}
