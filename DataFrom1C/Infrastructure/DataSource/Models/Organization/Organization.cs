using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.Organization
{
    public class Organization
    {
        [JsonPropertyName("value")]
        public OrganizationValue[] Value { get; set; }
    }
}
