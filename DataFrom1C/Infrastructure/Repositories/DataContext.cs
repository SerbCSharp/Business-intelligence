using DataFrom1C.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataFrom1C.Infrastructure.Repositories
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<PurchasePayment> PurchasePayments { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<SalesPayment> SalesPayments { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<PurchaseGoodAndService> PurchaseGoodsAndServices { get; set; }
        public DbSet<SalesGoodAndService> SalesGoodsAndServices { get; set; }
        public DbSet<ProductAndService> ProductsAndServices { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<CashFlowItem> CashFlowItems { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<MoreInformation> MoreInformations { get; set; }
        public DbSet<PaymentDetails> PaymentsDetails { get; set; }
        public DbSet<CostItem> CostItems { get; set; }
        public DbSet<ConstructionCompletionCertificate> ConstructionCompletionCertificates { get; set; }
        public DbSet<AccountingEntry> AccountingEntries { get; set; }
    }
}
