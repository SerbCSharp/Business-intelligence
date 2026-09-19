using System.Text.Json.Serialization;

namespace DataFrom1C.Infrastructure.DataSource.Models.DebtCorrection
{
    public class DebtCorrectionValue
    {
        public DateTime Date { get; set; }

        [JsonPropertyName("КредиторскаяЗадолженность")]
        public AccountsPayable[] AccountsPayable { get; set; }

        [JsonPropertyName("ДебиторскаяЗадолженность")]
        public AccountsReceivable[] AccountsReceivable { get; set; }
        public bool DeletionMark { get; set; }
    }
}
