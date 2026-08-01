using DataFromExcel.Domain;

namespace DataFromExcel.Application.Interfaces
{
    public interface ISaveData
    {
        Task ObjectOfSaleInPurchasePaymentAsync(IEnumerable<ObjectOfSaleInPurchasePayment> objectOfSaleInPurchasePayment);
        Task ObjectOfSaleInContractAsync(IEnumerable<ObjectOfSaleInContract> objectOfSaleInContract);
        Task ObjectOfSaleInPurchaseInvoiceAsync(IEnumerable<ObjectOfSaleInPurchaseInvoice> objectOfSaleInPurchaseInvoice);
    }
}
