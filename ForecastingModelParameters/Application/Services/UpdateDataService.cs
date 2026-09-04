using ForecastingModelParameters.Application.Interfaces;
using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Services
{
    public class UpdateDataService(IGetDataRepository getDataRepository, IGetDataSource getDataSource, ISaveData saveData)
    {
        private readonly IGetDataRepository _getDataRepository = getDataRepository;
        private readonly IGetDataSource _getDataSource = getDataSource;
        private readonly ISaveData _saveData = saveData;

        public async Task SaveAllProjectCostingDataAsync(string complexProperty)
        {
        }
    }
}
