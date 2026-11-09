using DataFromExcel.Application.Interfaces;

namespace DataFromExcel.Application.Services
{
    public class UpdateDataService(IGetData getData, ISaveData saveData, IConfiguration configuration)
    {
        private readonly IGetData _getData = getData;
        private readonly ISaveData _saveData = saveData;
        private readonly string company = configuration["FileSettings:CompanyId"];

        public async Task ObjectOfSaleInPurchasePaymentAsync()
        {
            var getObjectOfSaleInPurchasePayment = _getData.ObjectOfSaleInPurchasePayment();
            await _saveData.ObjectOfSaleInPurchasePaymentAsync(getObjectOfSaleInPurchasePayment, company);
        }

        public async Task ObjectOfSaleInContractAsync()
        {
            var getObjectOfSaleInContract = _getData.ObjectOfSaleInContract();
            await _saveData.ObjectOfSaleInContractAsync(getObjectOfSaleInContract, company);
        }

        public async Task TotalFloorAreaAsync()
        {
            var getTotalFloorArea = _getData.TotalFloorArea();
            await _saveData.TotalFloorAreaAsync(getTotalFloorArea, company);
        }

        public async Task AreaOfActivityAsync()
        {
            var getAreaOfActivity = _getData.AreaOfActivity();
            await _saveData.AreaOfActivityAsync(getAreaOfActivity, company);
        }

        public async Task AccountingTransactionAsync()
        {
            var getAccountingTransaction = _getData.AccountingTransaction();
            await _saveData.AccountingTransactionAsync(getAccountingTransaction, company);
        }

        public async Task SelectedCompanyAsync()
        {
            await _saveData.SelectedCompanyAsync(company);
        }
    }
}
