using ForecastingModelParameters.Domain;
using Microsoft.EntityFrameworkCore;

namespace ForecastingModelParameters.Infrastructure.Repositories
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<ProjectCostingData> ProjectCostingDatas { get; set; }
        public DbSet<ProjectCostingDataPeriod> ProjectCostingDataPeriods { get; set; }
        public DbSet<ReportField> ReportFields { get; set; }
    }
}
