using ForecastingModelParameters.Application.Interfaces;
using ForecastingModelParameters.Domain;
using Microsoft.EntityFrameworkCore;

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql
{
    public class MSSqlRepository(DataContext dataContext) : ISaveData, IGetData
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task<IEnumerable<ConstructionCostByProperty>> GetConstructionCostByPropertyAsync(string complexProperty)
        {
            return await _dataContext.ConstructionCostByProperties.Where(x => x.ComplexProperty == complexProperty).ToListAsync();
        }

        public async Task SaveConstructionCostByPropertyAsync(IEnumerable<ConstructionCostByProperty> constructionCostByProperty)
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
