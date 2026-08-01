using DataFromExcel.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataFromExcel.Infrastructure.Repositories
{
    public class ObjectOfSaleContext(DbContextOptions<ObjectOfSaleContext> options) : DbContext(options)
    {
        public DbSet<ObjectOfSaleInPurchasePayment> ObjectOfSaleInPurchasePayments { get; set; }
        public DbSet<ObjectOfSaleInContract> ObjectOfSaleInContracts { get; set; }
        public DbSet<ObjectOfSaleInPurchaseInvoice> ObjectOfSaleInPurchaseInvoices { get; set; }
    }
}
