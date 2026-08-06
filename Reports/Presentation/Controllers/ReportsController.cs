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
        public async Task<IActionResult> ProcurementPriceDynamics()
        {
            var procurementPrice = await _reportsService.ProcurementPriceAsync();
            var fileBytes = _exportingReportsToExcel.Browse(procurementPrice);
            string fileName = "Browse.xlsx";
            string contentType = "application/octet-stream";

            return File(fileBytes, contentType, fileName);
        }

        //[HttpGet("CostVsValueReport")]
        //public async Task<IActionResult> CostVsValueReport()
        //{
        //    var costVsValue = await _reportsService.CostVsValueAsync();
        //    var fileBytes = _exportingReportsToExcel.Browse(costVsValue);
        //    string fileName = "Browse.xlsx";
        //    string contentType = "application/octet-stream";

        //    return File(fileBytes, contentType, fileName);
        //}

        [HttpGet("ConstructionCost")]
        public async Task<IActionResult> ConstructionCost()
        {
            var constructionCost = await _reportsService.ConstructionCostAsync();
            var fileBytes = _exportingReportsToExcel.Browse(constructionCost);
            string fileName = "Browse.xlsx";
            string contentType = "application/octet-stream";

            return File(fileBytes, contentType, fileName);
        }

        [HttpGet("CostPerSquareMeter")]
        public async Task<IActionResult> CostPerSquareMeter()
        {
            var costPerSquareMeter = await _reportsService.CostPerSquareMeterAsync();
            var fileBytes = _exportingReportsToExcel.Browse(costPerSquareMeter);
            string fileName = "Browse.xlsx";
            string contentType = "application/octet-stream";

            return File(fileBytes, contentType, fileName);
        }

        [HttpGet("NonProductionCosts")]
        public async Task<IActionResult> NonProductionCosts()
        {
            var nonProductionCosts = await _reportsService.NonProductionCostsAsync();
            var fileBytes = _exportingReportsToExcel.Browse(nonProductionCosts);
            string fileName = "Browse.xlsx";
            string contentType = "application/octet-stream";

            return File(fileBytes, contentType, fileName);
        }
    }
}
