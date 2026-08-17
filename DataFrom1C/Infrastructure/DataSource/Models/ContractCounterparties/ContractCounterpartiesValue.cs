using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.ContractCounterparties
{
    public class ContractCounterpartiesValue
    {
        [JsonPropertyName("Ref_Key")]
        public string ContractId { get; set; }

        [JsonPropertyName("Номер")]
        public string Number { get; set; }

        [JsonPropertyName("Description")]
        public string Name { get; set; }

        [JsonPropertyName("Дата")]
        public DateTime? Date { get; set; }

        [JsonPropertyName("Сумма")]
        public decimal? Amount { get; set; }

        [JsonPropertyName("Owner_Key")]
        public string ContractorId { get; set; } // Подрядчик

        public string Code { get; set; }
    }
}
