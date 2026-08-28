using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Interfaces
{
    public interface IGetDataSource
    {
        IEnumerable<ConstructionCostByProperty> GetConstructionCostByProperty(string complexProperty);
        IEnumerable<SalesValueByCategory> GetSalesValueByCategory(string complexProperty);
        IEnumerable<ConstructionCostByPeriod> GetConstructionCostByPeriod(string complexProperty);
        IEnumerable<SalesValueByPeriod> GetSalesValueByPeriod(string complexProperty);
        IEnumerable<OtherFixedCost> GetOtherFixedCost(string complexProperty);
        IEnumerable<OtherFixedCostByPeriod> GetOtherFixedCostByPeriod(string complexProperty);
        IEnumerable<OtherPercentageCost> GetOtherPercentageCost(string complexProperty);
        IEnumerable<OtherPercentageCostByPeriod> GetOtherPercentageCostByPeriod(string complexProperty);
    }
}
