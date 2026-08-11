using Microsoft.AspNetCore.Mvc;
using Reports.Application.Services;
using Reports.Presentation.ReportsToExcel;

namespace Reports.Presentation.Controllers
{

    [ApiController]
    public class ReportsController(ReportsService reportsService, 
        ExportingReportsToExcel exportingReportsToExcel) : ControllerBase
    {
        private readonly ReportsService _reportsService = reportsService;
        private readonly ExportingReportsToExcel _exportingReportsToExcel = exportingReportsToExcel;

        [HttpGet("ProcurementPriceDynamics")]
        public async Task<IActionResult> ProcurementPriceDynamicsAsync()
        {
            var procurementPrice = await _reportsService.ProcurementPriceAsync();
            var fileBytes = _exportingReportsToExcel.Browse(procurementPrice);
            string fileName = "Browse.xlsx";
            string contentType = "application/octet-stream";

            return File(fileBytes, contentType, fileName);
        }

        [HttpGet("ConstructionCost")]
        public async Task<IActionResult> ConstructionCostAsync()
        {
            var constructionCost = await _reportsService.ConstructionCostAsync();
            var fileBytes = _exportingReportsToExcel.Browse(constructionCost);
            string fileName = "Browse.xlsx";
            string contentType = "application/octet-stream";

            return File(fileBytes, contentType, fileName);
        }

        [HttpGet("CostPerSquareMeter")]
        public async Task<IActionResult> CostPerSquareMeterAsync()
        {
            var costPerSquareMeter = await _reportsService.CostPerSquareMeterAsync();
            var fileBytes = _exportingReportsToExcel.Browse(costPerSquareMeter);
            string fileName = "Browse.xlsx";
            string contentType = "application/octet-stream";

            return File(fileBytes, contentType, fileName);
        }

        [HttpGet("NonProductionCosts")]
        public async Task<IActionResult> NonProductionCostsAsync()
        {
            var nonProductionCosts = await _reportsService.NonProductionCostsAsync();
            var fileBytes = _exportingReportsToExcel.NonProductionCosts(nonProductionCosts);
            string fileName = "NonProductionCosts.xlsx";
            string contentType = "application/octet-stream";

            return File(fileBytes, contentType, fileName);
        }

        [HttpGet("ProfitCenters")]
        public async Task<IActionResult> ProfitCentersAsync(DateTime startDate, DateTime endDate)
        {
            var profitCentersSource = await _reportsService.ProfitCentersSourceAsync(startDate, endDate);
            var fileBytes = _exportingReportsToExcel.Browse(profitCentersSource);

            var openingBalance = await _reportsService.OpeningBalanceAsync(startDate);


            string fileName = "ProfitCenters.xlsx";
            string contentType = "application/octet-stream";

            return File(fileBytes, contentType, fileName);
        }
    }
}
