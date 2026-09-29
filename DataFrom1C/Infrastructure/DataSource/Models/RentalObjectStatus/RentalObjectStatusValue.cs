using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.RentalObjectStatus
{
    public class RentalObjectStatusValue
    {
        public string Recorder { get; set; }

        [JsonPropertyName("RecordSet")]
        public RecordSet[] RecordSet { get; set; }
    }
}
