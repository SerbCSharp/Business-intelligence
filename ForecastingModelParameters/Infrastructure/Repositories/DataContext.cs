using ForecastingModelParameters.Domain;
using Microsoft.EntityFrameworkCore;

namespace ForecastingModelParameters.Infrastructure.Repositories
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        //public DbSet<ProjectCostingData> ProjectCostingDatas { get; set; }
        //public DbSet<ProjectCostingDataPeriod> ProjectCostingDataPeriods { get; set; }
        //public DbSet<ReportField> ReportFields { get; set; }

        //public DbSet<ProjectForecast> FactProjectForecasts { get; set; }
        //public DbSet<Date> DimDates { get; set; }
        //public DbSet<ComplexProperty> DimComplexProperties { get; set; }
        //public DbSet<Property> DimProperties { get; set; }
        //public DbSet<CostItem> DimCostItems { get; set; }
        //public DbSet<ReportLine> ReportLines { get; set; }
    }
}
