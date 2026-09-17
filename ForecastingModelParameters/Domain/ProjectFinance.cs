using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("DimProjectFinance", Schema = "params")]
    public class ProjectFinance
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; } // Например, «Проектное финансирование Сбербанк», «Кредитная линия ВТБ»
        public string ProjectFinanceDetailId { get; set; }
        
    }
}
