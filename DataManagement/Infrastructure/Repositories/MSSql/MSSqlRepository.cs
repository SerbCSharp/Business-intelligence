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
            return await _dbConnection.QueryAsync<AddObjectOfSaleInContract>("AddObjectOfSaleInContract");
        }

        public async Task<IEnumerable<AddAreaOfActivity>> AddAreaOfActivityAsync()
        {
            return await _dbConnection.QueryAsync<AddAreaOfActivity>("AddAreaOfActivity");
        }

        public async Task<IEnumerable<dynamic>> ExportAnyDataToExcelAsync()
        {
            return await _dbConnection.QueryAsync<dynamic>("ExportAnyDataToExcel");
        }
    }
}

