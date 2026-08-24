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

        public async Task<List<OtherCost>> GetOtherCostAsync(string complexProperty)
        {
            return await _dataContext.OtherCosts.Where(x => x.ComplexProperty == complexProperty).ToListAsync();
        }

        public async Task<List<OtherCostByPeriod>> GetOtherCostByPeriodAsync(string complexProperty)
        {
            return await _dataContext.OtherCostByPeriods.Where(x => x.ComplexProperty == complexProperty).ToListAsync();
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

        public async Task SaveOtherCostAsync(IEnumerable<OtherCost> otherCost, string complexProperty)
        {
            await _dataContext.OtherCosts.Where(x => x.ComplexProperty == complexProperty).ExecuteDeleteAsync();
            await _dataContext.OtherCosts.AddRangeAsync(otherCost);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SaveOtherCostByPeriodAsync(IEnumerable<OtherCostByPeriod> otherCostByPeriod, string complexProperty)
        {
            await _dataContext.OtherCostByPeriods.Where(x => x.ComplexProperty == complexProperty).ExecuteDeleteAsync();
            await _dataContext.OtherCostByPeriods.AddRangeAsync(otherCostByPeriod);
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
    }
}
