using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.ReceiptGoodsServices
{
    public class GoodAndService
    {
        [JsonPropertyName("ИдентификаторСтроки")]
        public string Id { get; set; }

        [JsonPropertyName("Ref_Key")]
        public string DocumentId { get; set; }

        [JsonPropertyName("Номенклатура_Key")]
        public string NomenclatureId { get; set; }

        [JsonPropertyName("ЕдиницаИзмерения_Key")]
        public string UnitsOfMeasureId { get; set; }

        [JsonPropertyName("Количество")]
        public decimal Quantity { get; set; }

        [JsonPropertyName("Цена")]
        public decimal Price { get; set; }

        [JsonPropertyName("Сумма")]
        public decimal Amount { get; set; }
    }
}
