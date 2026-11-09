using DataFrom1C.Domain;

namespace DataFrom1C.Application.Interfaces
{
    public interface ISaveData
    {
        Task PaymentAsync(IEnumerable<Payment> payments, string companyId);
        Task InvoiceAsync(IEnumerable<Invoice> invoices, string companyId);
        Task ContractAsync(IEnumerable<Contract> contracts, string companyId);
        Task ContractorAsync(IEnumerable<Contractor> contractors, string companyId);
        Task PurchaseGoodAndServiceAsync(IEnumerable<PurchaseGoodAndService> purchaseGoodAndService, string companyId);
        Task SalesGoodAndServiceAsync(IEnumerable<SalesGoodAndService> salesGoodAndService, string companyId);
        Task UnitAsync(IEnumerable<Unit> units, string companyId);
        Task ProductAndServiceAsync(IEnumerable<ProductAndService> productsAndServices, string companyId);
        Task WarehouseAsync(IEnumerable<Warehouse> warehouses, string companyId);
        Task CashFlowItemAsync(IEnumerable<CashFlowItem> cashFlowItems, string companyId);
        Task ProductGroupAsync(IEnumerable<ProductGroup> productGroups, string companyId);
        Task MoreInformationAsync(IEnumerable<MoreInformation> moreInformations, string companyId);
        Task PaymentDetailsAsync(IEnumerable<PaymentDetails> paymentDetails, string companyId);
        Task CostItemAsync(IEnumerable<CostItem> costItems, string companyId);
        Task ConstructionCompletionCertificateAsync(IEnumerable<ConstructionCompletionCertificate> constructionCompletionCertificates, string companyId);
        Task DebtAdjustmentAsync(IEnumerable<DebtAdjustment> debtAdjustment, string companyId);
        Task CommercialLeaseAsync(IEnumerable<CommercialLease> commercialLease, string companyId);
        Task CommercialLeaseStatusAsync(IEnumerable<CommercialLeaseStatus> commercialLeaseStatus, string companyId);
        Task CompanyAsync(IEnumerable<Company> company, string companyId);
    }
}
