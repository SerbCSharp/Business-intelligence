using ForecastingModelParameters.Domain;
using Microsoft.EntityFrameworkCore;

namespace ForecastingModelParameters.Infrastructure.Repositories
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<ProjectCostingData> ProjectCostingDatas { get; set; }
        public DbSet<ProjectCostingDataPeriod> ProjectCostingDataPeriods { get; set; }
        public DbSet<ReportField> ReportFields { get; set; }
        public DbSet<ConstructionExpense> ConstructionExpenses { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<ReportStructure> ReportStructures { get; set; }
        public DbSet<OtherExpense> OtherExpenses { get; set; }
    }
}
