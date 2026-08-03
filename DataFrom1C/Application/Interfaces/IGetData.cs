using DataFrom1C.Domain;

namespace DataFrom1C.Application.Interfaces
{
    public interface IGetData
    {
        Task<IEnumerable<PurchasePayment>> PurchasePaymentAsync();
        Task<IEnumerable<PurchaseInvoice>> PurchaseInvoiceAsync();
        Task<IEnumerable<SalesInvoice>> SalesInvoiceAsync();
        Task<IEnumerable<SalesPayment>> SalesPaymentAsync();
        Task<IEnumerable<Contract>> ContractAsync();
        Task<IEnumerable<Contractor>> ContractorAsync();
        Task<IEnumerable<PurchaseGoodAndService>> PurchaseGoodAndServiceAsync();
        Task<IEnumerable<SalesGoodAndService>> SalesGoodAndServiceAsync();
        Task<IEnumerable<Unit>> UnitAsync();
        Task<IEnumerable<ProductAndService>> ProductAndServiceAsync();
        Task<IEnumerable<Warehouse>> WarehouseAsync();
        Task<IEnumerable<CashFlowItem>> CashFlowItemAsync();
        Task<IEnumerable<ProductGroup>> ProductGroupAsync();
        Task<IEnumerable<MoreInformation>> MoreInformationAsync();
        Task<IEnumerable<PaymentDetails>> PaymentDetailsAsync();
        Task<IEnumerable<CostItem>> CostItemAsync();
        Task<IEnumerable<ConstructionCompletionCertificate>> ConstructionCompletionCertificateAsync();
    }
}
