using ForecastingModelParameters.Domain;
using Microsoft.EntityFrameworkCore;

namespace ForecastingModelParameters.Infrastructure.Repositories
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<ProjectCostingData> ProjectCostingDatas { get; set; }
        public DbSet<ProjectCostingDataPeriod> ProjectCostingDataPeriods { get; set; }
        public DbSet<ReportField> ReportFields { get; set; }

        public DbSet<ProjectForecast> FactProjectForecasts { get; set; }
        public DbSet<Date> DimDates { get; set; }
        public DbSet<ComplexProperty> DimComplexProperties { get; set; }
        public DbSet<Property> DimProperties { get; set; }
        public DbSet<CostItem> DimCostItems { get; set; }
        public DbSet<LoanTerm> DimLoanTerms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectForecast>().HasOne(u => u.Date).WithOne(p => p.ProjectForecast).HasForeignKey<Date>(p => p.ProjectForecastId);
            modelBuilder.Entity<ProjectForecast>().HasOne(u => u.ComplexProperty).WithOne(p => p.ProjectForecast).HasForeignKey<ComplexProperty>(p => p.ProjectForecastId);
            modelBuilder.Entity<ProjectForecast>().HasOne(u => u.Property).WithOne(p => p.ProjectForecast).HasForeignKey<Property>(p => p.ProjectForecastId);
            modelBuilder.Entity<ProjectForecast>().HasOne(u => u.CostItem).WithOne(p => p.ProjectForecast).HasForeignKey<CostItem>(p => p.ProjectForecastId);
            modelBuilder.Entity<ProjectForecast>().HasOne(u => u.LoanTerm).WithOne(p => p.ProjectForecast).HasForeignKey<LoanTerm>(p => p.ProjectForecastId);
        }
    }
}
