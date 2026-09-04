using ForecastingModelParameters.Domain;
using Microsoft.EntityFrameworkCore;

namespace ForecastingModelParameters.Infrastructure.Repositories
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<ReportField> ReportFields { get; set; }
    }
}
