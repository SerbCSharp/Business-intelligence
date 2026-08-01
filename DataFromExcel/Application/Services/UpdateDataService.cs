using DataFromExcel.Application.Interfaces;

namespace DataFromExcel.Application.Services
{
    public class UpdateDataService(IGetData getData, ISaveData saveData)
    {
        private readonly IGetData _getData = getData;
        private readonly ISaveData _saveData = saveData;

        public async Task ObjectOfSaleInPurchasePaymentAsync()
        {
            var getObjectOfSaleInPurchasePayment = _getData.ObjectOfSaleInPurchasePayment();
            await _saveData.ObjectOfSaleInPurchasePaymentAsync(getObjectOfSaleInPurchasePayment);
        }

        public async Task ObjectOfSaleInContractAsync()
        {
            var getObjectOfSaleInContract = _getData.ObjectOfSaleInContract();
            await _saveData.ObjectOfSaleInContractAsync(getObjectOfSaleInContract);
        }

        public async Task ObjectOfSaleInPurchaseInvoiceAsync()
        {
            var getObjectOfSaleInPurchaseInvoice = _getData.ObjectOfSaleInPurchaseInvoice();
            await _saveData.ObjectOfSaleInPurchaseInvoiceAsync(getObjectOfSaleInPurchaseInvoice);
        }
    }
}
