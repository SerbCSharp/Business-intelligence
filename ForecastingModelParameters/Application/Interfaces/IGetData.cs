using ForecastingModelParameters.Domain;

namespace ForecastingModelParameters.Application.Interfaces
{
    public interface IGetData
    {
        Task<IEnumerable<ConstructionCostByProperty>> ConstructionCostByPropertyAsync();
    }
}
