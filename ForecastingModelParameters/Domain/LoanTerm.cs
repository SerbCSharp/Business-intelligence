using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForecastingModelParameters.Domain
{
    [Table("DimLoanTerms", Schema = "params")]
    public class LoanTerm
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } // Например, «Проектное финансирование Сбербанк», «Кредитная линия ВТБ»
        public double EscrowFunding { get; set; } // Наполнение Эскроу-счетов (после погашения)
        public double InterestPayable { get; set; } // Проценты к уплате
        public double Principal { get; set; } // Сумма кредита
        public double KeyRate { get; set; } // Ключевая ставка

        public Guid ProjectForecastId { get; set; }
        public ProjectForecast ProjectForecast { get; set; }
    }
}
