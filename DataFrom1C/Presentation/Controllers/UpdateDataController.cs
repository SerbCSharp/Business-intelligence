using DataFrom1C.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataFrom1C.Presentation.Controllers
{
    [ApiController]
    public class UpdateDataController(UpdateDataService updateDataService) : ControllerBase
    {
        private readonly UpdateDataService _updateDataService = updateDataService;

        [HttpGet("Update")]
        public async Task<IActionResult> UpdateAsync()
        {
            await _updateDataService.PaymentAsync();
            await _updateDataService.PaymentDetailsAsync();
            await _updateDataService.MoreInformationAsync();
            await _updateDataService.CostItemAsync();

            await _updateDataService.InvoiceAsync();
            await _updateDataService.PurchaseGoodAndServiceAsync();
            await _updateDataService.SalesGoodAndServiceAsync();
            await _updateDataService.ProductAndServiceAsync();

            await _updateDataService.ContractAsync();
            await _updateDataService.ContractorAsync();
            await _updateDataService.UnitAsync();
            await _updateDataService.WarehouseAsync();
            await _updateDataService.CashFlowItemAsync();
            await _updateDataService.ProductGroupAsync();
            await _updateDataService.ConstructionCompletionCertificateAsync();
            await _updateDataService.DebtAdjustmentAsync();

            return NoContent();
        }
    }
}
