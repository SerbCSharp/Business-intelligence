using ForecastingModelParameters.Application.Interfaces;
using ForecastingModelParameters.Domain;
using Microsoft.EntityFrameworkCore;

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql
{
    public class MSSqlRepository(DataContext dataContext) : ISaveData, IGetDataRepository
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task<List<ConstructionCostByPeriod>> GetConstructionCostByPeriodAsync(string complexProperty)
        {
            return await _dataContext.ConstructionCostByPeriods.Where(x => x.ComplexProperty == complexProperty).ToListAsync();
        }

        public async Task<List<ConstructionCostByProperty>> GetConstructionCostByPropertyAsync(string complexProperty)
        {
            return await _dataContext.ConstructionCostByProperties.Where(x => x.ComplexProperty == complexProperty).ToListAsync();
        }

        public async Task<List<OtherFixedCost>> GetOtherFixedCostAsync(string complexProperty)
        {
            return await _dataContext.OtherFixedCosts.Where(x => x.ComplexProperty == complexProperty).ToListAsync();
        }

        public async Task<List<OtherPercentageCost>> GetOtherPercentageCostAsync(string complexProperty)
        {
            return await _dataContext.OtherPercentageCosts.Where(x => x.ComplexProperty == complexProperty).ToListAsync();
        }

        public async Task<List<OtherFixedCostByPeriod>> GetOtherFixedCostByPeriodAsync(string complexProperty)
        {
            return await _dataContext.OtherFixedCostByPeriods.Where(x => x.ComplexProperty == complexProperty).ToListAsync();
        }

        public async Task<List<SalesValueByCategory>> GetSalesValueByCategoryAsync(string complexProperty)
        {
            return await _dataContext.SalesValueByCategories.Where(x => x.ComplexProperty == complexProperty).ToListAsync();
        }

        public async Task<List<SalesValueByPeriod>> GetSalesValueByPeriodAsync(string complexProperty)
        {
            return await _dataContext.SalesValueByPeriods.Where(x => x.ComplexProperty == complexProperty).ToListAsync();
        }

        public async Task<List<ReportField>> GetReportFieldAsync()
        {
            return await _dataContext.ReportFields.ToListAsync();
        }

        public async Task SaveConstructionCostByPeriodAsync(IEnumerable<ConstructionCostByPeriod> constructionCostByPeriod, string complexProperty)
        {
            await _dataContext.ConstructionCostByPeriods.Where(x => x.ComplexProperty == complexProperty).ExecuteDeleteAsync();
            await _dataContext.ConstructionCostByPeriods.AddRangeAsync(constructionCostByPeriod);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SaveConstructionCostByPropertyAsync(IEnumerable<ConstructionCostByProperty> constructionCostByProperty, string complexProperty)
        {
            await _dataContext.ConstructionCostByProperties.Where(x => x.ComplexProperty == complexProperty).ExecuteDeleteAsync();
            await _dataContext.ConstructionCostByProperties.AddRangeAsync(constructionCostByProperty);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SaveSalesValueByCategoryAsync(IEnumerable<SalesValueByCategory> salesValueByCategory, string complexProperty)
        {
            await _dataContext.SalesValueByCategories.Where(x => x.ComplexProperty == complexProperty).ExecuteDeleteAsync();
            await _dataContext.SalesValueByCategories.AddRangeAsync(salesValueByCategory);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SaveSalesValueByPeriodAsync(IEnumerable<SalesValueByPeriod> salesValueByPeriod, string complexProperty)
        {
            await _dataContext.SalesValueByPeriods.Where(x => x.ComplexProperty == complexProperty).ExecuteDeleteAsync();
            await _dataContext.SalesValueByPeriods.AddRangeAsync(salesValueByPeriod);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SaveOtherFixedCostAsync(IEnumerable<OtherFixedCost> otherFixedCost, string complexProperty)
        {
            await _dataContext.OtherFixedCosts.Where(x => x.ComplexProperty == complexProperty).ExecuteDeleteAsync();
            await _dataContext.OtherFixedCosts.AddRangeAsync(otherFixedCost);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SaveOtherFixedCostByPeriodAsync(IEnumerable<OtherFixedCostByPeriod> otherFixedCostByPeriod, string complexProperty)
        {
            await _dataContext.OtherFixedCostByPeriods.Where(x => x.ComplexProperty == complexProperty).ExecuteDeleteAsync();
            await _dataContext.OtherFixedCostByPeriods.AddRangeAsync(otherFixedCostByPeriod);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SaveOtherPercentageCostAsync(IEnumerable<OtherPercentageCost> otherPercentageCost, string complexProperty)
        {
            await _dataContext.OtherPercentageCosts.Where(x => x.ComplexProperty == complexProperty).ExecuteDeleteAsync();
            await _dataContext.OtherPercentageCosts.AddRangeAsync(otherPercentageCost);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SaveOtherPercentageCostByPeriodAsync(IEnumerable<OtherPercentageCostByPeriod> оtherPercentageCostByPeriod, string complexProperty)
        {
            await _dataContext.OtherPercentageCostByPeriods.Where(x => x.ComplexProperty == complexProperty).ExecuteDeleteAsync();
            await _dataContext.OtherPercentageCostByPeriods.AddRangeAsync(оtherPercentageCostByPeriod);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<OtherPercentageCostByPeriod>> GetOtherPercentageCostByPeriodAsync(string complexProperty)
        {
            return await _dataContext.OtherPercentageCostByPeriods.Where(x => x.ComplexProperty == complexProperty).ToListAsync();
        }
    }
}
