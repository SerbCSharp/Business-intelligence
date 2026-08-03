using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.ConstructionOrder
{
    public class ConstructionOrderValue
    {
        [JsonPropertyName("ДоговорКонтрагента_Key")]
        public string ContractId { get; set; }

        [JsonPropertyName("ДатаНачала")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("ДатаОкончания")]
        public DateTime EndDate { get; set; }
    }
}
