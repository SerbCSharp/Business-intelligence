using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.RentalObjectStatus
{
    public class RentalObjectStatus
    {
        [JsonPropertyName("value")]
        public RentalObjectStatusValue[] Value { get; set; }
    }
}
