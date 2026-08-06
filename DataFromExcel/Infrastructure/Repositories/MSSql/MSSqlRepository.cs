using DataFromExcel.Application.Interfaces;
using DataFromExcel.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataFromExcel.Infrastructure.Repositories.MSSql
{
    public class MSSqlRepository(ObjectOfSaleContext dataContext) : ISaveData
    {
        private readonly ObjectOfSaleContext _dataContext = dataContext;

        public async Task ObjectOfSaleInPurchasePaymentAsync(IEnumerable<ObjectOfSaleInPurchasePayment> objectOfSaleInPurchasePayment)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE ObjectOfSaleInPurchasePayments");
            await _dataContext.ObjectOfSaleInPurchasePayments.AddRangeAsync(objectOfSaleInPurchasePayment);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ObjectOfSaleInContractAsync(IEnumerable<ObjectOfSaleInContract> objectOfSaleInContract)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE ObjectOfSaleInContracts");
            await _dataContext.ObjectOfSaleInContracts.AddRangeAsync(objectOfSaleInContract);
            await _dataContext.SaveChangesAsync();
        }

        public async Task TotalFloorAreaAsync(IEnumerable<TotalFloorArea> totalFloorAreas)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE TotalFloorAreas");
            await _dataContext.TotalFloorAreas.AddRangeAsync(totalFloorAreas);
            await _dataContext.SaveChangesAsync();
        }
    }
}
