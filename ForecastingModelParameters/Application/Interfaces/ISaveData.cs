using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Interfaces
{
    public interface ISaveData
    {
        Task SaveConstructionCostByPropertyAsync(IEnumerable<ConstructionCostByProperty> constructionCostByProperty, string complexProperty);
        Task SaveSalesValueByCategoryAsync(IEnumerable<SalesValueByCategory> salesValueByCategory, string complexProperty);
    }
}
