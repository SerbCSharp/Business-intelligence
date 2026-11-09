using DataFrom1C.Application.Interfaces;

namespace DataFrom1C.Application.Services
{
    public class UpdateDataService(IGetData getData, ISaveData saveData, IConfiguration configuration)
    {
        private readonly IGetData _getData = getData;
        private readonly ISaveData _saveData = saveData;
        private readonly string company = configuration["Base1CConfiguration:CompanyId"];


        public async Task PaymentAsync()
        {
            var getPayment = await _getData.PaymentAsync();
            await _saveData.PaymentAsync(getPayment, company);
        }

        public async Task InvoiceAsync()
        {
            var getInvoice = await _getData.InvoiceAsync();
            await _saveData.InvoiceAsync(getInvoice, company);
        }

        public async Task ContractAsync()
        {
            var getContract = await _getData.ContractAsync();
            await _saveData.ContractAsync(getContract, company);
        }

        public async Task ContractorAsync()
        {
            var getContractor = await _getData.ContractorAsync();
            await _saveData.ContractorAsync(getContractor, company);
        }

        public async Task PurchaseGoodAndServiceAsync()
        {
            var getPurchaseGoodAndService = await _getData.PurchaseGoodAndServiceAsync();
            await _saveData.PurchaseGoodAndServiceAsync(getPurchaseGoodAndService, company);
        }

        public async Task SalesGoodAndServiceAsync()
        {
            var getSalesGoodAndService = await _getData.SalesGoodAndServiceAsync();
            await _saveData.SalesGoodAndServiceAsync(getSalesGoodAndService, company);
        }

        public async Task UnitAsync()
        {
            var getUnit = await _getData.UnitAsync();
            await _saveData.UnitAsync(getUnit, company);
        }

        public async Task ProductAndServiceAsync()
        {
            var getProductAndService = await _getData.ProductAndServiceAsync();
            await _saveData.ProductAndServiceAsync(getProductAndService, company);
        }

        public async Task WarehouseAsync()
        {
            var getWarehouse = await _getData.WarehouseAsync();
            await _saveData.WarehouseAsync(getWarehouse, company);
        }

        public async Task CashFlowItemAsync()
        {
            var getCashFlowItem = await _getData.CashFlowItemAsync();
            await _saveData.CashFlowItemAsync(getCashFlowItem, company);
        }

        public async Task ProductGroupAsync()
        {
            var getProductGroup = await _getData.ProductGroupAsync();
            await _saveData.ProductGroupAsync(getProductGroup, company);
        }
        public async Task MoreInformationAsync()
        {
            var getMoreInformation = await _getData.MoreInformationAsync();
            await _saveData.MoreInformationAsync(getMoreInformation, company);
        }

        public async Task PaymentDetailsAsync()
        {
            var getPaymentDetails = await _getData.PaymentDetailsAsync();
            await _saveData.PaymentDetailsAsync(getPaymentDetails, company);
        }

        public async Task CostItemAsync()
        {
            var getCostItem = await _getData.CostItemAsync();
            await _saveData.CostItemAsync(getCostItem, company);
        }

        public async Task ConstructionCompletionCertificateAsync()
        {
            var getConstructionCompletionCertificate = await _getData.ConstructionCompletionCertificateAsync();
            await _saveData.ConstructionCompletionCertificateAsync(getConstructionCompletionCertificate, company);
        }

        public async Task DebtAdjustmentAsync()
        {
            var getDebtAdjustment = await _getData.DebtAdjustmentAsync();
            await _saveData.DebtAdjustmentAsync(getDebtAdjustment, company);
        }

        public async Task CommercialLeaseAsync()
        {
            var getCommercialLease = await _getData.CommercialLeaseAsync();
            await _saveData.CommercialLeaseAsync(getCommercialLease, company);
        }

        public async Task CommercialLeaseStatusAsync()
        {
            var getCommercialLeaseStatus = await _getData.CommercialLeaseStatusAsync();
            await _saveData.CommercialLeaseStatusAsync(getCommercialLeaseStatus, company);
        }

        public async Task CompanyAsync()
        {
            var getCompany = await _getData.CompanyAsync();
            await _saveData.CompanyAsync(getCompany, company);
        }
    }
}
