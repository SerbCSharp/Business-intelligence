using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.RentalObject
{
    public class RentalObject
    {
        [JsonPropertyName("value")]
        public RentalObjectValue[] Value { get; set; }
    }
}
