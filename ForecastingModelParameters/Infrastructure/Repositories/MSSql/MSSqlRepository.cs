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
            return await _dataContext.ProjectCostingDatas.Include(x => x.ProjectCostingDataPeriods)
                .Where(y => y.ComplexProperty == complexProperty).ToListAsync();
        }

        public async Task<List<ReportField>> ReportFieldAsync()
        {
            return await _dataContext.ReportFields.ToListAsync();
        }
    }
}
