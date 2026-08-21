using ForecastingModelParameters.Domain;
using Microsoft.EntityFrameworkCore;

namespace ForecastingModelParameters.Infrastructure.Repositories
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<ConstructionCostByProperty> ConstructionCostByProperties { get; set; }
        public DbSet<ConstructionCostByPeriod> ConstructionCostByPeriods { get; set; }
        public DbSet<SalesValueByCategory> SalesValueByCategories { get; set; }
        public DbSet<SalesValueByPeriod> SalesValueByPeriods { get; set; }
        public DbSet<OtherCost> OtherCosts { get; set; }
        public DbSet<OtherCostByPeriod> OtherCostByPeriods { get; set; }
    }
}
