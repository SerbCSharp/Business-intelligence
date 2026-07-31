using Reports.Application.Interfaces;
using Reports.Domain;

namespace Reports.Application.Services
{
    public class ProcurementPriceService(IGetData getData)
    {
        private readonly IGetData _getData = getData;

        public async Task<IEnumerable<ProcurementPrice>> ProcurementPriceAsync()
        {
            return await _getData.ProcurementPriceAsync();
        }
    }
}
