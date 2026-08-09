using Dapper;
using DataManagement.Application.Interfaces;
using DataManagement.Domain;
using System.Data;

namespace DataManagement.Infrastructure.Repositories.MSSql
{
    public class MSSqlRepository(IDbConnection dbConnection) : IGetData
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<IEnumerable<AddObjectOfSaleInPurchasePayment>> AddObjectOfSaleInPurchasePaymentAsync()
        {
            return await _dbConnection.QueryAsync<AddObjectOfSaleInPurchasePayment>("AddObjectOfSaleInPurchasePayment");
        }

        public async Task<IEnumerable<AddObjectOfSaleInContract>> AddObjectOfSaleInContractAsync()
        {
            string sql = "WITH AllProperty AS (SELECT Contracts.ContractId, ObjectOfSaleInPurchasePayments.Property, Contracts.CodeContract, " +
                                "ObjectOfSaleInPurchasePayments.CostItem AS CostItem, Contracts.Number, Contracts.Name, Contractors.Name AS Contractor, " +
                                "ROW_NUMBER() OVER(PARTITION BY Contracts.ContractId ORDER BY CASE WHEN ObjectOfSaleInPurchasePayments.ContractId IS NOT NULL THEN 0 ELSE 1 END) AS RowNum, " +
                                "COUNT(*) OVER (PARTITION BY Contracts.ContractId) AS TotalContractId " +
                            "FROM Contracts " +
                            "LEFT JOIN Contractors ON Contracts.ContractorId = Contractors.ContractorId " +
                            "LEFT JOIN ObjectOfSaleInPurchasePayments ON Contracts.ContractId = ObjectOfSaleInPurchasePayments.ContractId) " +

                         "SELECT * FROM AllProperty WHERE RowNum = 1 AND CAST(RIGHT(CodeContract, 6) AS INT) > 2780";

            return await _dbConnection.QueryAsync<AddObjectOfSaleInContract>(sql);
        }

        public async Task<IEnumerable<AddAreaOfActivity>> AddAreaOfActivityAsync()
        {
            return await _dbConnection.QueryAsync<AddAreaOfActivity>("AddAreaOfActivity");
        }
    }
}

