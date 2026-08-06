using DataManagement.Domain;

namespace DataManagement.Application.Interfaces
{
    public interface IGetData
    {
        Task<IEnumerable<AddObjectOfSaleInPurchasePayment>> AddObjectOfSaleInPurchasePaymentAsync();
        Task<IEnumerable<AddObjectOfSaleInContract>> AddObjectOfSaleInContractAsync();
    }
}
