using DataManagement.Application.Interfaces;
using DataManagement.Domain;

namespace DataManagement.Application.Services
{
    public class DataManagementService(IGetData getData)
    {
        private readonly IGetData _getData = getData;

        public async Task<IEnumerable<AddObjectOfSaleInPurchasePayment>> AddObjectOfSaleInPurchasePaymentAsync()
        {
            return await _getData.AddObjectOfSaleInPurchasePaymentAsync();
        }

        public async Task<IEnumerable<AddObjectOfSaleInContract>> AddObjectOfSaleInContractAsync()
        {
            return await _getData.AddObjectOfSaleInContractAsync();
        }

        public async Task<IEnumerable<AddObjectOfSaleInPurchaseInvoice>> AddObjectOfSaleInPurchaseInvoiceAsync()
        {
            return await _getData.AddObjectOfSaleInPurchaseInvoiceAsync();
        }
    }
}
