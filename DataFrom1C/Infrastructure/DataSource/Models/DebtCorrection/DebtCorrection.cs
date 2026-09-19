using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.DebtCorrection
{
    public class DebtCorrection
    {
        [JsonPropertyName("value")]
        public DebtCorrectionValue[] Value { get; set; }
    }
}
