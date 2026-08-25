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
            return await _dbConnection.QueryAsync<ProcurementPrice>("ProcurementPrice");
        }

        public async Task<IEnumerable<ConstructionCost>> ConstructionCostAsync()
        {
            var contractor = await _dbConnection.QueryAsync<ConstructionCost>("ConstructionCostContractor");
            var supplier = await _dbConnection.QueryAsync<ConstructionCost>("ConstructionCostSupplier");

            return contractor.Concat(supplier);
        }

        public async Task<IEnumerable<CostPerSquareMeter>> CostPerSquareMeterAsync()
        {
            return await _dbConnection.QueryAsync<CostPerSquareMeter>("CostPerSquareMeter");
        }

        public async Task<IEnumerable<NonProductionCosts>> NonProductionCostsAsync()
        {
            return await _dbConnection.QueryAsync<NonProductionCosts>("NonProductionCosts");
        }

        public async Task<IEnumerable<ProfitCentersSource>> ProfitCentersSourceAsync(DateTime startDate, DateTime endDate)
        {
            return await _dbConnection.QueryAsync<ProfitCentersSource>("ProfitCenters", new { StartDate = startDate, EndDate = endDate });
        }

        public async Task<decimal> OpeningBalanceAsync(DateTime startDate)
        {
            return await _dbConnection.ExecuteScalarAsync<decimal>("OpeningBalance", new { StartDate = startDate });
        }

        public async Task<IEnumerable<ConstructionCostByPeriod>> ConstructionCostByPeriodAsync(string complexProperty)
        {
            return await _dbConnection.QueryAsync<ConstructionCostByPeriod>("ConstructionCostByPeriod", new { ComplexProperty = complexProperty });
        }

        public async Task<IEnumerable<SalesTarget>> SalesTargetAsync(string complexProperty)
        {
            return await _dbConnection.QueryAsync<SalesTarget>("SalesTarget", new { ComplexProperty = complexProperty });
        }

        public async Task<IEnumerable<CashFlow>> CashFlowAsync(string complexProperty)
        {
            return await _dbConnection.QueryAsync<CashFlow>("CashFlow", new { ComplexProperty = complexProperty });
        }
    }
}
