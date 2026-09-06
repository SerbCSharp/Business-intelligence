using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Interfaces
{
    public interface ISaveData
    {
        Task SaveProjectCostingDataAsync(IEnumerable<ProjectCostingData> projectCostingDatas, string complexProperty);
    }
}
