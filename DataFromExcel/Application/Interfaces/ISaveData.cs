using DataFromExcel.Domain;

namespace DataFromExcel.Application.Interfaces
{
    public interface ISaveData
    {
        Task ObjectOfSaleInPurchasePaymentAsync(IEnumerable<ObjectOfSaleInPurchasePayment> objectOfSaleInPurchasePayment);
        Task ObjectOfSaleInContractAsync(IEnumerable<ObjectOfSaleInContract> objectOfSaleInContract);
        Task TotalFloorAreaAsync(IEnumerable<TotalFloorArea> totalFloorArea);
        Task AreaOfActivityAsync(IEnumerable<AreaOfActivityPayment> areaOfActivity);
        Task AccountingTransactionAsync(IEnumerable<AccountingTransaction> accountingTransaction);
        Task SelectedCompanyAsync(string selectedCompany);
    }
}
