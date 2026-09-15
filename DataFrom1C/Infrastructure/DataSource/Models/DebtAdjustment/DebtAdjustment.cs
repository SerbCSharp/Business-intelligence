using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.DebtAdjustment
{
    public class DebtAdjustment
    {
        [JsonPropertyName("value")]
        public DebtAdjustmentValue[] Value { get; set; }
    }
}
