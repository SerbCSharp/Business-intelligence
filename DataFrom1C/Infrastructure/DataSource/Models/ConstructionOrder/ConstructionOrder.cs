using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.ConstructionOrder
{
    public class ConstructionOrder
    {
        [JsonPropertyName("value")]
        public ConstructionOrderValue[] Value { get; set; }
    }
}
