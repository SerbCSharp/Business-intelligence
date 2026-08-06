using DataManagement.Application.Services;
using DataManagement.Presentation.ReportsToExcel;
using Microsoft.AspNetCore.Mvc;

namespace DataManagement.Presentation.Controllers
{
    [ApiController]
    public class DataManagementControllers(DataManagementService dataManagementService,
        ExportingReportsToExcel exportingReportsToExcel) : Controller
    {
        private readonly DataManagementService _dataManagementService = dataManagementService;
        private readonly ExportingReportsToExcel _exportingReportsToExcel = exportingReportsToExcel;

        [HttpGet("AddObjectOfSaleInPurchasePayment")]
        public async Task<IActionResult> AddObjectOfSaleInPurchasePaymentAsync()
        {
            var addObjectOfSaleInPurchasePayment = await _dataManagementService.AddObjectOfSaleInPurchasePaymentAsync();
            var fileBytes = _exportingReportsToExcel.Browse(addObjectOfSaleInPurchasePayment);
            string fileName = "Browse.xlsx";
            string contentType = "application/octet-stream";

            return File(fileBytes, contentType, fileName);
        }

        [HttpGet("AddObjectOfSaleInContract")]
        public async Task<IActionResult> AddObjectOfSaleInContractAsync()
        {
            var addObjectOfSaleInContract = await _dataManagementService.AddObjectOfSaleInContractAsync();
            var fileBytes = _exportingReportsToExcel.Browse(addObjectOfSaleInContract);
            string fileName = "Browse.xlsx";
            string contentType = "application/octet-stream";

            return File(fileBytes, contentType, fileName);
        }
    }
}
