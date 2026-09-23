using DataFromExcel.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataFromExcel.Infrastructure.Repositories
{
    public class ObjectOfSaleContext(DbContextOptions<ObjectOfSaleContext> options) : DbContext(options)
    {
        public DbSet<ObjectOfSaleInPurchasePayment> ObjectOfSaleInPurchasePayments { get; set; }
        public DbSet<ObjectOfSaleInContract> ObjectOfSaleInContracts { get; set; }
        public DbSet<TotalFloorArea> TotalFloorAreas { get; set; }
        public DbSet<AreaOfActivityPayment> AreaOfActivityPayments { get; set; }
        public DbSet<AccountingTransaction> AccountingTransactions { get; set; }
        public DbSet<CashBalance> CashBalances { get; set; }
    }
}
