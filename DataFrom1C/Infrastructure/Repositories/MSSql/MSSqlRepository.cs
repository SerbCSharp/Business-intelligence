using DataFrom1C.Application.Interfaces;
using DataFrom1C.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataFrom1C.Infrastructure.Repositories.MSSql
{
    public class MSSqlRepository(DataContext dataContext) : ISaveData
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task PaymentAsync(IEnumerable<Payment> payments)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Payments");
            await _dataContext.Payments.AddRangeAsync(payments);
            await _dataContext.SaveChangesAsync();
        }

        public async Task InvoiceAsync(IEnumerable<Invoice> invoices)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Invoices");
            await _dataContext.Invoices.AddRangeAsync(invoices);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ContractAsync(IEnumerable<Contract> contract)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Contracts");
            await _dataContext.Contracts.AddRangeAsync(contract);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ContractorAsync(IEnumerable<Contractor> contractor)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Contractors");
            await _dataContext.Contractors.AddRangeAsync(contractor);
            await _dataContext.SaveChangesAsync();
        }

        public async Task PurchaseGoodAndServiceAsync(IEnumerable<PurchaseGoodAndService> purchaseGoodAndService)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE PurchaseGoodsAndServices");
            await _dataContext.PurchaseGoodsAndServices.AddRangeAsync(purchaseGoodAndService);
            await _dataContext.SaveChangesAsync();
        }

        public async Task SalesGoodAndServiceAsync(IEnumerable<SalesGoodAndService> salesGoodAndService)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE SalesGoodsAndServices");
            await _dataContext.SalesGoodsAndServices.AddRangeAsync(salesGoodAndService);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UnitAsync(IEnumerable<Unit> units)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Units");
            await _dataContext.Units.AddRangeAsync(units);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ProductAndServiceAsync(IEnumerable<ProductAndService> productsAndServices)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE ProductsAndServices");
            await _dataContext.ProductsAndServices.AddRangeAsync(productsAndServices);
            await _dataContext.SaveChangesAsync();
        }

        public async Task WarehouseAsync(IEnumerable<Warehouse> warehouses)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Warehouses");
            await _dataContext.Warehouses.AddRangeAsync(warehouses);
            await _dataContext.SaveChangesAsync();
        }

        public async Task CashFlowItemAsync(IEnumerable<CashFlowItem> cashFlowItems)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE CashFlowItems");
            await _dataContext.CashFlowItems.AddRangeAsync(cashFlowItems);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ProductGroupAsync(IEnumerable<ProductGroup> productGroups)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE ProductGroups");
            await _dataContext.ProductGroups.AddRangeAsync(productGroups);
            await _dataContext.SaveChangesAsync();
        }
        public async Task MoreInformationAsync(IEnumerable<MoreInformation> moreInformations)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE MoreInformations");
            if (moreInformations != null)
                await _dataContext.MoreInformations.AddRangeAsync(moreInformations);
            await _dataContext.SaveChangesAsync();
        }

        public async Task PaymentDetailsAsync(IEnumerable<PaymentDetails> paymentDetails)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE PaymentsDetails");
            await _dataContext.PaymentsDetails.AddRangeAsync(paymentDetails);
            await _dataContext.SaveChangesAsync();
        }

        public async Task CostItemAsync(IEnumerable<CostItem> costItems)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE CostItems");
            await _dataContext.CostItems.AddRangeAsync(costItems);
            await _dataContext.SaveChangesAsync();
        }

        public async Task ConstructionCompletionCertificateAsync(IEnumerable<ConstructionCompletionCertificate> constructionCompletionCertificates)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE ConstructionCompletionCertificates");
            if (constructionCompletionCertificates != null) await _dataContext.ConstructionCompletionCertificates.AddRangeAsync(constructionCompletionCertificates);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DebtAdjustmentAsync(IEnumerable<DebtAdjustment> debtAdjustment)
        {
            await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE DebtAdjustments");
            await _dataContext.DebtAdjustments.AddRangeAsync(debtAdjustment);
            await _dataContext.SaveChangesAsync();
        }
    }
}
