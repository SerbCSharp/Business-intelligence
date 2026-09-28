using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.RentalObject
{
    public class RentalObjectValue
    {
        public string Ref_Key { get; set; }
        public string Description { get; set; }

        [JsonPropertyName("Parent_Key")]
        public string ParentId { get; set; }

        [JsonPropertyName("ТипОбъекта_Key")]
        public string PropertyTypeId { get; set; }
    }
}
