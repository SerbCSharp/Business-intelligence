using DataFrom1C.Application.Interfaces;

namespace DataFrom1C.Application.Services
{
    public class UpdateDataService(IGetData getData, ISaveData saveData)
    {
        private readonly IGetData _getData = getData;
        private readonly ISaveData _saveData = saveData;

        public async Task PurchasePaymentAsync()
        {
            var getPurchasePayment = await _getData.PurchasePaymentAsync();
            await _saveData.PurchasePaymentAsync(getPurchasePayment);
        }

        public async Task PurchaseInvoiceAsync()
        {
            var getPurchaseInvoice = await _getData.PurchaseInvoiceAsync();
            await _saveData.PurchaseInvoiceAsync(getPurchaseInvoice);
        }

        public async Task SalesInvoiceAsync()
        {
            var getSalesInvoice = await _getData.SalesInvoiceAsync();
            await _saveData.SalesInvoiceAsync(getSalesInvoice);
        }

        public async Task SalesPaymentAsync()
        {
            var getSalesPayment = await _getData.SalesPaymentAsync();
            await _saveData.SalesPaymentAsync(getSalesPayment);
        }

        public async Task ContractAsync()
        {
            var getContract = await _getData.ContractAsync();
            await _saveData.ContractAsync(getContract);
        }

        public async Task ContractorAsync()
        {
            var getContractor = await _getData.ContractorAsync();
            await _saveData.ContractorAsync(getContractor);
        }

        public async Task PurchaseGoodAndServiceAsync()
        {
            var getPurchaseGoodAndServiceAsync = await _getData.PurchaseGoodAndServiceAsync();
            await _saveData.PurchaseGoodAndServiceAsync(getPurchaseGoodAndServiceAsync);
        }

        public async Task SalesGoodAndServiceAsync()
        {
            var getSalesGoodAndService = await _getData.SalesGoodAndServiceAsync();
            await _saveData.SalesGoodAndServiceAsync(getSalesGoodAndService);
        }

        public async Task UnitAsync()
        {
            var getUnit = await _getData.UnitAsync();
            await _saveData.UnitAsync(getUnit);
        }

        public async Task ProductAndServiceAsync()
        {
            var getProductAndService = await _getData.ProductAndServiceAsync();
            await _saveData.ProductAndServiceAsync(getProductAndService);
        }

        public async Task WarehouseAsync()
        {
            var getWarehouse = await _getData.WarehouseAsync();
            await _saveData.WarehouseAsync(getWarehouse);
        }

        public async Task CashFlowItemAsync()
        {
            var getCashFlowItem = await _getData.CashFlowItemAsync();
            await _saveData.CashFlowItemAsync(getCashFlowItem);
        }

        public async Task ProductGroupAsync()
        {
            var getProductGroup = await _getData.ProductGroupAsync();
            await _saveData.ProductGroupAsync(getProductGroup);
        }
        public async Task MoreInformationAsync()
        {
            var getMoreInformation = await _getData.MoreInformationAsync();
            await _saveData.MoreInformationAsync(getMoreInformation);
        }

        public async Task PaymentDetailsAsync()
        {
            var getPaymentDetails = await _getData.PaymentDetailsAsync();
            await _saveData.PaymentDetailsAsync(getPaymentDetails);
        }

        public async Task CostItemAsync()
        {
            var getCostItem = await _getData.CostItemAsync();
            await _saveData.CostItemAsync(getCostItem);
        }

        public async Task ConstructionCompletionCertificateAsync()
        {
            var getConstructionCompletionCertificate = await _getData.ConstructionCompletionCertificateAsync();
            await _saveData.ConstructionCompletionCertificateAsync(getConstructionCompletionCertificate);
        }

        public async Task AccountingEntryAsync()
        {
            var getAccountingEntry = await _getData.AccountingEntryAsync();
            await _saveData.AccountingEntryAsync(getAccountingEntry);
        }

        public async Task PlanOfAccountsAsync()
        {
            var getPlanOfAccounts = await _getData.PlanOfAccountsAsync();
            await _saveData.PlanOfAccountsAsync(getPlanOfAccounts);
        }
    }
}
