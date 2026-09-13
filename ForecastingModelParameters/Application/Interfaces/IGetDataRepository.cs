using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Interfaces
{
    public interface IGetDataRepository
    {
        Task<List<ProjectCostingData>> ProjectCostingDataAsync(string complexProperty);
        Task<List<ReportField>> ReportFieldAsync();

        Task<IEnumerable<Revenue>> RevenueAsync(string complexProperty);
        Task<IEnumerable<ConstructionExpense>> ConstructionExpenseAsync(string complexProperty);
        Task<IEnumerable<OtherExpense>> OtherExpenseAsync(string complexProperty);
        Task<IEnumerable<ReportStructure>> ReportStructureAsync();

    }
}
