using ForecastingModelParameters.Application.Interfaces;
using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Infrastructure.Repositories.MSSql
{
    public class MSSqlRepository(DataContext dataContext) : ISaveData
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task ConstructionCostByPropertyAsync(IEnumerable<ConstructionCostByProperty> constructionCostByProperty)
        {
            _dataContext.ConstructionCostByProperties.UpdateRange(constructionCostByProperty);
            await _dataContext.SaveChangesAsync();
        }
    }
}
