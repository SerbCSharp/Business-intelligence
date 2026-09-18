using ForecastingModelParameters.Application.Interfaces;
using ForecastingModelParameters.Domain;
using Microsoft.EntityFrameworkCore;

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql
{
    public class MSSqlRepository(DataContext dataContext) : ISaveData, IGetDataRepository
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task<List<ProjectCostingData>> ProjectCostingDataAsync(string complexProperty)
        {
            //return await _dataContext.ProjectCostingDatas.Include(x => x.ProjectCostingDataPeriods)
            //    .Where(y => y.ComplexProperty == complexProperty).ToListAsync();
            return null;
        }

        public async Task<List<ProjectForecast>> ProjectForecastAsync(string complexProperty)
        {
            //return await _dataContext.FactProjectForecasts
            //    .Where(y => y.ComplexPropertyId.ToLower() == complexProperty.ToLower())
            //    .ToListAsync();
            return null;
        }

        public async Task<List<ReportField>> ReportFieldAsync()
        {
            //return await _dataContext.ReportFields.ToListAsync();
            return null;
        }

        public async Task SaveProjectCostingDataAsync(IEnumerable<ProjectCostingData> projectCostingDatas, string complexProperty)
        {
            //await _dataContext.ProjectCostingDatas.Where(x => x.ComplexProperty == complexProperty).ExecuteDeleteAsync();
            //await _dataContext.ProjectCostingDatas.AddRangeAsync(projectCostingDatas);
            //await _dataContext.SaveChangesAsync();
        }
    }
}
