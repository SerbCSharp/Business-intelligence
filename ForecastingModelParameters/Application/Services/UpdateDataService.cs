using ForecastingModelParameters.Application.Interfaces;

namespace ForecastingModelParameters.Application.Services
{
    public class UpdateDataService(ISaveData saveData)
    {
        //private readonly IGetData _getData = getData;
        private readonly ISaveData _saveData = saveData;

        public async Task ConstructionCostByPropertyAsync()
        {
            //var getConstructionCostByProperty = await _getData.ConstructionCostByPropertyAsync();
            //await _saveData.ConstructionCostByPropertyAsync(getConstructionCostByProperty);
        }
    }
}
