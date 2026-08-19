using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Interfaces
{
    public interface ISaveData
    {
        Task ConstructionCostByPropertyAsync(IEnumerable<ConstructionCostByProperty> constructionCostByProperty);
    }
}
