using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.RentalObjectStatus
{
    public class RecordSet
    {
        [JsonPropertyName("Договор_Key")]
        public string ContractId { get; set; }

        [JsonPropertyName("Услуга_Key")]
        public string ServiceId { get; set; }

        [JsonPropertyName("ОбъектАренды_Key")]
        public string RentalObjectId { get; set; }

        [JsonPropertyName("ДатаНачалаАренды")]
        public DateTime StartDate { get; set; }

        [JsonPropertyName("ДатаОкончанияАренды")]
        public DateTime EndDate { get; set; }

        [JsonPropertyName("Статус")]
        public string Status { get; set; }
    }
}
