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

        public async Task<IEnumerable<ConstructionCost>> ConstructionCostAsync()
        {
            string contractorSql = "WITH Payment AS (SELECT SUM(Amount) AS PaymentAmount, ContractId " +
                                        "FROM PurchasePayments " +
                                        "GROUP BY ContractId), " +
                                   "Invoice AS (SELECT SUM(Amount) AS InvoiceAmount, ContractId " +
                                        "FROM PurchaseInvoices " +
                                        "GROUP BY ContractId) " +
                                   
                                   "SELECT Contractors.Name AS Contractor, Number, Date, ObjectOfSaleInContracts.Amount AS ContractAmount, " +
                                            "Payment.PaymentAmount, Invoice.InvoiceAmount, " +
                                            "ObjectOfSaleInContracts.Property, ObjectOfSaleInContracts.CostItem " +
                                        "FROM Contracts " +
                                        "LEFT JOIN Contractors ON Contracts.ContractorId = Contractors.ContractorId " +
                                        "INNER JOIN ObjectOfSaleInContracts ON Contracts.ContractId = ObjectOfSaleInContracts.ContractId " +
                                        "LEFT JOIN Payment ON Contracts.ContractId = Payment.ContractId " +
                                        "LEFT JOIN Invoice ON Contracts.ContractId = Invoice.ContractId ";
            string supplierSql = "WITH Payment AS (SELECT SUM(PurchasePayments.Amount) AS PaymentAmount, PurchasePayments.ContractId," +
                                        "ObjectOfSaleInPurchasePayments.Property, ObjectOfSaleInPurchasePayments.CostItem " +
                                    "FROM PurchasePayments " +
                                    "LEFT JOIN ObjectOfSaleInPurchasePayments ON PurchasePayments.DocumentId = ObjectOfSaleInPurchasePayments.DocumentId " +
                                    "GROUP BY PurchasePayments.ContractId, ObjectOfSaleInPurchasePayments.Property, ObjectOfSaleInPurchasePayments.CostItem), " +
                                 "Supplier AS (SELECT Contractors.Name AS Contractor, Number, Date, Payment.PaymentAmount, Payment.Property, Payment.CostItem " +
                                    "FROM Contracts " +
                                    "LEFT JOIN Contractors ON Contracts.ContractorId = Contractors.ContractorId " +
                                    "LEFT JOIN ObjectOfSaleInContracts ON Contracts.ContractId = ObjectOfSaleInContracts.ContractId " +
                                    "LEFT JOIN Payment ON Contracts.ContractId = Payment.ContractId " +
                                    "WHERE ObjectOfSaleInContracts.Amount IS NULL) " +
                                 
                                 "SELECT * FROM Supplier WHERE Property IS NOT NULL";
            var contractor = await _dbConnection.QueryAsync<ConstructionCost>(contractorSql);
            var supplier = await _dbConnection.QueryAsync<ConstructionCost>(supplierSql);

            return contractor.Concat(supplier);
        }

        public async Task<IEnumerable<CostPerSquareMeter>> CostPerSquareMeterAsync()
        {
            string sql = "WITH CostPerSquareMeter AS (SELECT SUM(Amount) AS Amount, Property " +
                            "FROM PurchasePayments " +
                            "INNER JOIN ObjectOfSaleInPurchasePayments ON PurchasePayments.DocumentId = ObjectOfSaleInPurchasePayments.DocumentId " +
                            "GROUP BY Property) " +
                         "SELECT Amount, CostPerSquareMeter.Property, TotalArea " +
                            "FROM CostPerSquareMeter " +
                            "LEFT JOIN TotalFloorAreas ON CostPerSquareMeter.Property = TotalFloorAreas.Property";
            return await _dbConnection.QueryAsync<CostPerSquareMeter>(sql);
        }

        public async Task<IEnumerable<NonProductionCosts>> NonProductionCostsAsync()
        {
            string sql = "WITH NonProductionCosts AS (SELECT SUM(PurchasePayments.Amount) AS Amount, " +
                                "YEAR(PurchasePayments.Date) AS [Year], MONTH(PurchasePayments.Date) AS [Month] " +
                            "FROM PurchasePayments " +
                            "LEFT JOIN ObjectOfSaleInPurchasePayments ON PurchasePayments.DocumentId = ObjectOfSaleInPurchasePayments.DocumentId " +
                            "WHERE ObjectOfSaleInPurchasePayments.Property IS NULL AND PurchasePayments.CashFlowItemId != '942e3217-065d-11f1-8ad0-345a60ea423c' " +
                            "AND PurchasePayments.CashFlowItemId != '697d9306-7d1d-11ed-93f4-a85e452bf5ea' AND PurchasePayments.CashFlowItemId != '71512e7f-065a-11f1-8ad0-345a60ea423c' " +
                            "GROUP BY YEAR(PurchasePayments.Date), MONTH(PurchasePayments.Date)), " +
                         "ProductionCosts AS (SELECT SUM(PurchasePayments.Amount) AS Amount, YEAR(PurchasePayments.Date) AS [Year], " +
                                "MONTH(PurchasePayments.Date) AS [Month] " +
                            "FROM PurchasePayments " +
                            "LEFT JOIN ObjectOfSaleInPurchasePayments ON PurchasePayments.DocumentId = ObjectOfSaleInPurchasePayments.DocumentId " +
                            "WHERE ObjectOfSaleInPurchasePayments.Property IS NOT NULL AND PurchasePayments.CashFlowItemId != '71512e7f-065a-11f1-8ad0-345a60ea423c' " +
                            "GROUP BY YEAR(PurchasePayments.Date), MONTH(PurchasePayments.Date)) " +
                         
                         "SELECT NonProductionCosts.Amount AS NonProductionAmount, ProductionCosts.Amount AS ProductionAmount, " +
                                "NonProductionCosts.[Year], NonProductionCosts.[Month] " +
                            "FROM NonProductionCosts " +
                            "INNER JOIN ProductionCosts ON NonProductionCosts.[Year] = ProductionCosts.[Year] " +
                                "AND NonProductionCosts.[Month] = ProductionCosts.[Month] " +
                            "ORDER BY NonProductionCosts.[Year], NonProductionCosts.[Month]";
            return await _dbConnection.QueryAsync<NonProductionCosts>(sql);
        }

        public async Task<IEnumerable<ProfitCenters>> ProfitCentersAsync(DateTime startDate, DateTime endDate)
        {
            string sql = "WITH Payment AS (SELECT *, Amount AS Debit, 0.00 AS Credit " +
                            "FROM PurchasePayments " +
                            "UNION ALL " +
                            "SELECT *, 0.00 AS Debit, Amount AS Credit " +
                            "FROM SalesPayments) " +
                         "SELECT Payment.Date, TypeOfActivity, AreaOfActivity, TypeOperation, Debit, Credit, [Percent], DirectOrIndirect, ContractIdIncome, " +
                                "PaymentPurpose, Contracts.Number, Contractors.Name AS Contractor FROM Payment " +
                            "LEFT JOIN AreaOfActivityPayments ON Payment.DocumentId = AreaOfActivityPayments.DocumentId " +
                            "LEFT JOIN Contracts ON Payment.ContractId = Contracts.ContractId " +
                            "LEFT JOIN Contractors ON Contracts.ContractorId = Contractors.ContractorId " +
                            "WHERE Payment.Date BETWEEN @StartDate AND @EndDate " +
                            "ORDER BY Payment.Date";
            return await _dbConnection.QueryAsync<ProfitCenters>(sql, new { StartDate = startDate, EndDate = endDate });
        }

        public async Task<decimal> OpeningBalanceAsync(DateTime startDate)
        {
            return await _dbConnection.ExecuteScalarAsync<decimal>("OpeningBalance", new { StartDate = startDate });
        }

    }
}
