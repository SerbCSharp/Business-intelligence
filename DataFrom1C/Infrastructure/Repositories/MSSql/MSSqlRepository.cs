using DataFrom1C.Application.Interfaces;
using DataFrom1C.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataFrom1C.Infrastructure.Repositories.MSSql
{
    public class MSSqlRepository(DataContext dataContext) : ISaveData
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task PaymentAsync(IEnumerable<Payment> payments, string companyId)
        {
            var deleteRows = $"DELETE FROM Payments WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            await _dataContext.Payments.AddRangeAsync(payments);
            await _dataContext.SaveChangesAsync();
        }

        public async Task InvoiceAsync(IEnumerable<Invoice> invoices, string companyId)
        {
            var deleteRows = $"DELETE FROM Invoices WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            await _dataContext.Invoices.AddRangeAsync(invoices);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ContractAsync(IEnumerable<Contract> contract, string companyId)
        {
            var deleteRows = $"DELETE FROM Contracts WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            await _dataContext.Contracts.AddRangeAsync(contract);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ContractorAsync(IEnumerable<Contractor> contractor, string companyId)
        {
            var deleteRows = $"DELETE FROM Contractors WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            await _dataContext.Contractors.AddRangeAsync(contractor);
            await _dataContext.SaveChangesAsync();
        }

        public async Task PurchaseGoodAndServiceAsync(IEnumerable<PurchaseGoodAndService> purchaseGoodAndService, string companyId)
        {
            var deleteRows = $"DELETE FROM PurchaseGoodsAndServices WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            await _dataContext.PurchaseGoodsAndServices.AddRangeAsync(purchaseGoodAndService);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SalesGoodAndServiceAsync(IEnumerable<SalesGoodAndService> salesGoodAndService, string companyId)
        {
            var deleteRows = $"DELETE FROM SalesGoodsAndServices WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            await _dataContext.SalesGoodsAndServices.AddRangeAsync(salesGoodAndService);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UnitAsync(IEnumerable<Unit> units, string companyId)
        {
            var deleteRows = $"DELETE FROM Units WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            await _dataContext.Units.AddRangeAsync(units);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ProductAndServiceAsync(IEnumerable<ProductAndService> productsAndServices, string companyId)
        {
            var deleteRows = $"DELETE FROM ProductsAndServices WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            await _dataContext.ProductsAndServices.AddRangeAsync(productsAndServices);
            await _dataContext.SaveChangesAsync();
        }

        public async Task WarehouseAsync(IEnumerable<Warehouse> warehouses, string companyId)
        {
            var deleteRows = $"DELETE FROM Warehouses WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            await _dataContext.Warehouses.AddRangeAsync(warehouses);
            await _dataContext.SaveChangesAsync();
        }

        public async Task CashFlowItemAsync(IEnumerable<CashFlowItem> cashFlowItems, string companyId)
        {
            var deleteRows = $"DELETE FROM CashFlowItems WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            await _dataContext.CashFlowItems.AddRangeAsync(cashFlowItems);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ProductGroupAsync(IEnumerable<ProductGroup> productGroups, string companyId)
        {
            var deleteRows = $"DELETE FROM ProductGroups WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            await _dataContext.ProductGroups.AddRangeAsync(productGroups);
            await _dataContext.SaveChangesAsync();
        }
        public async Task MoreInformationAsync(IEnumerable<MoreInformation> moreInformations, string companyId)
        {
            var deleteRows = $"DELETE FROM MoreInformations WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            if (moreInformations != null)
                await _dataContext.MoreInformations.AddRangeAsync(moreInformations);
            await _dataContext.SaveChangesAsync();
        }

        public async Task PaymentDetailsAsync(IEnumerable<PaymentDetails> paymentDetails, string companyId)
        {
            var deleteRows = $"DELETE FROM PaymentsDetails WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            await _dataContext.PaymentsDetails.AddRangeAsync(paymentDetails);
            await _dataContext.SaveChangesAsync();
        }

        public async Task CostItemAsync(IEnumerable<CostItem> costItems, string companyId)
        {
            var deleteRows = $"DELETE FROM CostItems WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            await _dataContext.CostItems.AddRangeAsync(costItems);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ConstructionCompletionCertificateAsync(IEnumerable<ConstructionCompletionCertificate> constructionCompletionCertificates, string companyId)
        {
            var deleteRows = $"DELETE FROM ConstructionCompletionCertificates WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            if (constructionCompletionCertificates != null) await _dataContext.ConstructionCompletionCertificates.AddRangeAsync(constructionCompletionCertificates);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DebtAdjustmentAsync(IEnumerable<DebtAdjustment> debtAdjustment, string companyId)
        {
            var deleteRows = $"DELETE FROM DebtAdjustments WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            await _dataContext.DebtAdjustments.AddRangeAsync(debtAdjustment);
            await _dataContext.SaveChangesAsync();
        }

        public async Task CommercialLeaseAsync(IEnumerable<CommercialLease> commercialLease, string companyId)
        {
            var deleteRows = $"DELETE FROM CommercialLeases WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            if (commercialLease != null) await _dataContext.CommercialLeases.AddRangeAsync(commercialLease);
            await _dataContext.SaveChangesAsync();
        }

        public async Task CommercialLeaseStatusAsync(IEnumerable<CommercialLeaseStatus> commercialLeaseStatus, string companyId)
        {
            var deleteRows = $"DELETE FROM CommercialLeaseStatuses WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            if (commercialLeaseStatus != null) await _dataContext.CommercialLeaseStatuses.AddRangeAsync(commercialLeaseStatus);
            await _dataContext.SaveChangesAsync();
        }

        public async Task CompanyAsync(IEnumerable<Company> company, string companyId)
        {
            var deleteRows = $"DELETE FROM Companies WHERE CompanyId = '{companyId}'";
            await _dataContext.Database.ExecuteSqlRawAsync(deleteRows);
            await _dataContext.Companies.AddRangeAsync(company);
            await _dataContext.SaveChangesAsync();
        }
    }
}
