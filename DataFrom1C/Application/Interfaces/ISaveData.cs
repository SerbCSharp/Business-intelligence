using DataFrom1C.Domain;

namespace DataFrom1C.Application.Interfaces
{
    public interface ISaveData
    {
        Task PurchasePaymentAsync(IEnumerable<PurchasePayment> purchasePayments);
        Task PurchaseInvoiceAsync(IEnumerable<PurchaseInvoice> purchaseInvoices);
        Task SalesInvoiceAsync(IEnumerable<SalesInvoice> salesInvoices);
        Task SalesPaymentAsync(IEnumerable<SalesPayment> salesPayments);
        Task ContractAsync(IEnumerable<Contract> contracts);
        Task ContractorAsync(IEnumerable<Contractor> contractors);
        Task PurchaseGoodAndServiceAsync(IEnumerable<PurchaseGoodAndService> purchaseGoodAndService);
        Task SalesGoodAndServiceAsync(IEnumerable<SalesGoodAndService> salesGoodAndService);
        Task UnitAsync(IEnumerable<Unit> units);
        Task ProductAndServiceAsync(IEnumerable<ProductAndService> productsAndServices);
        Task WarehouseAsync(IEnumerable<Warehouse> warehouses);
        Task CashFlowItemAsync(IEnumerable<CashFlowItem> cashFlowItems);
        Task ProductGroupAsync(IEnumerable<ProductGroup> productGroups);
        Task MoreInformationAsync(IEnumerable<MoreInformation> moreInformations);
        Task PaymentDetailsAsync(IEnumerable<PaymentDetails> paymentDetails);
        Task CostItemAsync(IEnumerable<CostItem> costItems);
        Task ConstructionCompletionCertificateAsync(IEnumerable<ConstructionCompletionCertificate> constructionCompletionCertificates);
        Task AccountingEntryAsync(IEnumerable<AccountingEntry> accountingEntries);
    }
}
