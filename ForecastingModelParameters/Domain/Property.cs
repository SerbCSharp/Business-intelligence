using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("DimProperties", Schema = "params")]
    public class Property
    {
        [Key]
        public int Id { get; set; } // ID корпуса или заглушки (например, -1 с именем «Общие расходы по ЖК»)
        public string Name { get; set; }
        public string CommissioningOfResidentialProperty { get; set; } // Дата ввода в эксплуатацию (ссылка на DateId)

        public Guid ProjectForecastId { get; set; }
        public ProjectForecast ProjectForecast { get; set; }
    }
}
