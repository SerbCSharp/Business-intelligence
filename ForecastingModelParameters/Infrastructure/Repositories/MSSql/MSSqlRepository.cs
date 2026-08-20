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

        public async Task<List<SalesValueByCategory>> GetSalesValueByCategoryAsync(string complexProperty)
        {
            return await _dataContext.SalesValueByCategories.Where(x => x.ComplexProperty == complexProperty).ToListAsync();
        }

        public async Task<List<SalesValueByPeriod>> GetSalesValueByPeriodAsync(string complexProperty)
        {
            return await _dataContext.SalesValueByPeriods.Where(x => x.ComplexProperty == complexProperty).ToListAsync();
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
    }
}
