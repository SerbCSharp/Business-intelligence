using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Interfaces
{
    public interface ISaveData
    {
        Task SaveConstructionCostByPropertyAsync(IEnumerable<ConstructionCostByProperty> constructionCostByProperty, string complexProperty);
        Task SaveSalesValueByCategoryAsync(IEnumerable<SalesValueByCategory> salesValueByCategory, string complexProperty);
        Task SaveConstructionCostByPeriodAsync(IEnumerable<ConstructionCostByPeriod> constructionCostByPeriod, string complexProperty);
        Task SaveSalesValueByPeriodAsync(IEnumerable<SalesValueByPeriod> salesValueByPeriod, string complexProperty);
        Task SaveOtherCostAsync(IEnumerable<OtherCost> otherCost, string complexProperty);
        Task SaveOtherCostByPeriodAsync(IEnumerable<OtherCostByPeriod> otherCostByPeriod, string complexProperty);
    }
}
