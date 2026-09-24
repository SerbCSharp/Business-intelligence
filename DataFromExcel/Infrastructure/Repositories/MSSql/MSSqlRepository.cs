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
            if (objectOfSaleInPurchasePayment != null)
                await _dataContext.ObjectOfSaleInPurchasePayments.AddRangeAsync(objectOfSaleInPurchasePayment);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ObjectOfSaleInContractAsync(IEnumerable<ObjectOfSaleInContract> objectOfSaleInContract)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE ObjectOfSaleInContracts");
            if (objectOfSaleInContract != null)
                await _dataContext.ObjectOfSaleInContracts.AddRangeAsync(objectOfSaleInContract);
            await _dataContext.SaveChangesAsync();
        }

        public async Task TotalFloorAreaAsync(IEnumerable<TotalFloorArea> totalFloorAreas)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE TotalFloorAreas");
            if (totalFloorAreas != null)
                await _dataContext.TotalFloorAreas.AddRangeAsync(totalFloorAreas);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AreaOfActivityAsync(IEnumerable<AreaOfActivityPayment> areaOfActivity)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE AreaOfActivityPayments");
            if (areaOfActivity != null)
                await _dataContext.AreaOfActivityPayments.AddRangeAsync(areaOfActivity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AccountingTransactionAsync(IEnumerable<AccountingTransaction> accountingTransaction)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE AccountingTransactions");
            if (accountingTransaction != null)
                await _dataContext.AccountingTransactions.AddRangeAsync(accountingTransaction);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SelectedCompanyAsync(string selectedCompany)
        {
            if (selectedCompany != null)
            {
                await _dataContext.CashBalances.Where(x => x.Company != selectedCompany).ExecuteUpdateAsync(y => y.SetProperty(u => u.IsSelected, false));
                await _dataContext.CashBalances.Where(x => x.Company == selectedCompany).ExecuteUpdateAsync(y => y.SetProperty(u => u.IsSelected, true));
            }
        }
    }
}
