using ForecastingModelParameters.Application.Interfaces;
using ForecastingModelParameters.Domain;
using Microsoft.EntityFrameworkCore;

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql
{
    public class MSSqlRepository(DataContext dataContext) : ISaveData, IGetDataRepository
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task<List<ReportField>> ReportFieldAsync()
        {
            return await _dataContext.ReportFields.ToListAsync();
        }
    }
}
