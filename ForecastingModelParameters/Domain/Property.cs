using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("DimProperties", Schema = "params")]
    public class Property
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> CommissioningOfResidentialProperty { get; set; } // Дата ввода в эксплуатацию (ссылка на DateId)
    }
}
