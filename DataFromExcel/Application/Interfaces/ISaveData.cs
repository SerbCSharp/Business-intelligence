using DataFromExcel.Domain;

namespace DataFromExcel.Application.Interfaces
{
    public interface ISaveData
    {
        Task ObjectOfSaleInPurchasePaymentAsync(IEnumerable<ObjectOfSaleInPurchasePayment> objectOfSaleInPurchasePayment, string companyId);
        Task ObjectOfSaleInContractAsync(IEnumerable<ObjectOfSaleInContract> objectOfSaleInContract, string companyId);
        Task TotalFloorAreaAsync(IEnumerable<TotalFloorArea> totalFloorArea, string companyId);
        Task AreaOfActivityAsync(IEnumerable<AreaOfActivityPayment> areaOfActivity, string companyId);
        Task AccountingTransactionAsync(IEnumerable<AccountingTransaction> accountingTransaction, string companyId);
        Task SelectedCompanyAsync(string companyId);
    }
}
