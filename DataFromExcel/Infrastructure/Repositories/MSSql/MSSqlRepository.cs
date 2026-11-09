using DataFromExcel.Application.Interfaces;
using DataFromExcel.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataFromExcel.Infrastructure.Repositories.MSSql
{
    public class MSSqlRepository(ObjectOfSaleContext dataContext) : ISaveData
    {
        private readonly ObjectOfSaleContext _dataContext = dataContext;

        public async Task ObjectOfSaleInPurchasePaymentAsync(IEnumerable<ObjectOfSaleInPurchasePayment> objectOfSaleInPurchasePayment, string companyId)
        {
            var deleteRows = $"DELETE FROM ObjectOfSaleInPurchasePayments WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            if (objectOfSaleInPurchasePayment != null)
                await _dataContext.ObjectOfSaleInPurchasePayments.AddRangeAsync(objectOfSaleInPurchasePayment);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ObjectOfSaleInContractAsync(IEnumerable<ObjectOfSaleInContract> objectOfSaleInContract, string companyId)
        {
            var deleteRows = $"DELETE FROM ObjectOfSaleInContracts WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            if (objectOfSaleInContract != null)
                await _dataContext.ObjectOfSaleInContracts.AddRangeAsync(objectOfSaleInContract);
            await _dataContext.SaveChangesAsync();
        }

        public async Task TotalFloorAreaAsync(IEnumerable<TotalFloorArea> totalFloorAreas, string companyId)
        {
            var deleteRows = $"DELETE FROM TotalFloorAreas WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            if (totalFloorAreas != null)
                await _dataContext.TotalFloorAreas.AddRangeAsync(totalFloorAreas);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AreaOfActivityAsync(IEnumerable<AreaOfActivityPayment> areaOfActivity, string companyId)
        {
            var deleteRows = $"DELETE FROM AreaOfActivityPayments WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            if (areaOfActivity != null)
                await _dataContext.AreaOfActivityPayments.AddRangeAsync(areaOfActivity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task AccountingTransactionAsync(IEnumerable<AccountingTransaction> accountingTransaction, string companyId)
        {
            var deleteRows = $"DELETE FROM AccountingTransactions WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            if (accountingTransaction != null)
                await _dataContext.AccountingTransactions.AddRangeAsync(accountingTransaction);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SelectedCompanyAsync(string companyId)
        {
            if (companyId != null)
            {
                await _dataContext.CashBalances.Where(x => x.CompanyId != companyId).ExecuteUpdateAsync(y => y.SetProperty(u => u.IsSelected, false));
                await _dataContext.CashBalances.Where(x => x.CompanyId == companyId).ExecuteUpdateAsync(y => y.SetProperty(u => u.IsSelected, true));
            }
        }
    }
}
