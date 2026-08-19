using ForecastingModelParameters.Application.Interfaces;
using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Services
{
    public class UpdateDataService(IGetData getData, ISaveData saveData)
    {
        private readonly IGetData _getData = getData;
        private readonly ISaveData _saveData = saveData;

        public async Task<IEnumerable<ConstructionCostByProperty>> GetConstructionCostByPropertyAsync(string complexProperty, int property)
        {
            var getConstructionCostByProperty = await _getData.GetConstructionCostByPropertyAsync(complexProperty);
            if (getConstructionCostByProperty.Count() == 0)
            { }
            return getConstructionCostByProperty;
        }
    }
}
