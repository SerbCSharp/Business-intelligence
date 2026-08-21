using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Interfaces
{
    public interface IGetDataSource
    {
        IEnumerable<ConstructionCostByProperty> GetConstructionCostByProperty(string complexProperty);
        IEnumerable<SalesValueByCategory> GetSalesValueByCategory(string complexProperty);
        IEnumerable<ConstructionCostByPeriod> GetConstructionCostByPeriod(string complexProperty);
        IEnumerable<SalesValueByPeriod> GetSalesValueByPeriod(string complexProperty);
        IEnumerable<OtherCost> GetOtherCost(string complexProperty);
        IEnumerable<OtherCostByPeriod> GetOtherCostByPeriod(string complexProperty);
    }
}
