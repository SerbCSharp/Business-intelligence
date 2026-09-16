using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("DimLoanTerms", Schema = "params")]
    public class LoanTerm
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } // Например, «Проектное финансирование Сбербанк», «Кредитная линия ВТБ»
    }
}
