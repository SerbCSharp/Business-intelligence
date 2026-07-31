using Reports.Domain;

namespace Reports.Application.Interfaces
{
    public interface IGetData
    {
        Task<IEnumerable<ProcurementPrice>> ProcurementPriceAsync();
    }
}
