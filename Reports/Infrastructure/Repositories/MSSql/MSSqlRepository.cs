using Dapper;
using Reports.Application.Interfaces;
using Reports.Domain;
using System.Data;

namespace Reports.Infrastructure.Repositories.MSSql
{
    public class MSSqlRepository(IDbConnection dbConnection) : IGetData
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<IEnumerable<ProcurementPrice>> ProcurementPriceAsync()
        {
            string sql = "SELECT PurchaseInvoices.Date, PurchaseInvoices.Amount AS DocumentAmount, " +
                                "PurchaseGoodsAndServices.Quantity, Units.Name AS Unit, ProductsAndServices.Name AS ProductAndService, " +
                                "PurchaseGoodsAndServices.Price, PurchaseGoodsAndServices.Amount," +
                                "Contractors.Name AS Contractor, Warehouses.Name AS Warehouse " +
                            "FROM PurchaseInvoices " +
                            "LEFT JOIN PurchaseGoodsAndServices ON PurchaseInvoices.DocumentId = PurchaseGoodsAndServices.DocumentId " +
                            "LEFT JOIN Contracts ON PurchaseInvoices.ContractId = Contracts.ContractId " +
                            "LEFT JOIN Contractors ON Contracts.ContractorId = Contractors.ContractorId " +
                            "LEFT JOIN Warehouses ON PurchaseInvoices.WarehouseId = Warehouses.WarehouseId " +
                            "LEFT JOIN Units ON PurchaseGoodsAndServices.UnitId = Units.UnitId " +
                            "LEFT JOIN ProductsAndServices ON PurchaseGoodsAndServices.ProductAndServiceId = ProductsAndServices.ProductAndServiceId " +
                            "ORDER BY PurchaseInvoices.Date";
            return await _dbConnection.QueryAsync<ProcurementPrice>(sql);
        }

        public async Task<IEnumerable<CostVsValue>> CostVsValueAsync()
        {
            string sql = "WITH Cost AS (SELECT SUM(PurchasePayments.Amount) AS PaymentsAmount, YEAR(PurchasePayments.Date) AS [Year], " +
                                "MONTH(PurchasePayments.Date) AS [Month], ObjectOfSaleInPurchasePayments.ComplexProperty " +
                            "FROM PurchasePayments " +
                            "INNER JOIN ObjectOfSaleInPurchasePayments ON PurchasePayments.DocumentId = ObjectOfSaleInPurchasePayments.DocumentId " +
                            "GROUP BY ObjectOfSaleInPurchasePayments.ComplexProperty, YEAR(PurchasePayments.Date), MONTH(PurchasePayments.Date)), " +
                         "[Value] AS (SELECT SUM(PurchaseInvoices.Amount) AS InvoicesAmount, YEAR(PurchaseInvoices.Date) AS [Year], " +
                            "MONTH(PurchaseInvoices.Date) AS [Month], ObjectOfSaleInPurchaseInvoices.ComplexProperty " +
                            "FROM PurchaseInvoices " +
                            "INNER JOIN ObjectOfSaleInPurchaseInvoices ON PurchaseInvoices.DocumentId = ObjectOfSaleInPurchaseInvoices.DocumentId " +
                            "GROUP BY ObjectOfSaleInPurchaseInvoices.ComplexProperty, YEAR(PurchaseInvoices.Date), MONTH(PurchaseInvoices.Date)) " +
                
                         "SELECT Cost.PaymentsAmount, [Value].InvoicesAmount, Cost.[Year], Cost.[Month], Cost.ComplexProperty " +
                            "FROM Cost " +
                            "INNER JOIN [Value] ON Cost.ComplexProperty = [Value].ComplexProperty AND Cost.[Year] = [Value].[Year] AND Cost.[Month] = [Value].[Month]";
            return await _dbConnection.QueryAsync<CostVsValue>(sql);
        }
    }
}
