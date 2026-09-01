using Microsoft.AspNetCore.Mvc;
using Reports.Application.Services;
using Reports.Presentation.ReportsToExcel;
using System.ComponentModel.DataAnnotations;

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
            var fileBytes = _exportingReportsToExcel.ConstructionCost(constructionCost);
            string fileName = "ConstructionCost.xlsx";
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
            var package = _exportingReportsToExcel.ProfitCentersSource(profitCentersSource);

            var openingBalance = await _reportsService.OpeningBalanceAsync(startDate);
            var profitCenters = _reportsService.ProfitCenters(profitCentersSource);
            var fileBytes = _exportingReportsToExcel.ProfitCenters(package, profitCenters, openingBalance, startDate, endDate);

            string fileName = "ProfitCenters.xlsx";
            string contentType = "application/octet-stream";

            return File(fileBytes, contentType, fileName);
        }

        [HttpGet("ConstructionForecastingModel")]
        public async Task<IActionResult> ConstructionForecastingModelAsync([Required] string complexProperty)
        {
            var constructionCostByPeriod = await _reportsService.ConstructionCostByPeriodAsync(complexProperty);
            var package = _exportingReportsToExcel.ConstructionCostByPeriod(constructionCostByPeriod);

            var salesTarget = await _reportsService.SalesTargetAsync(complexProperty);
            _exportingReportsToExcel.SalesTarget(package, salesTarget);

            var otherCost = await _reportsService.OtherCostAsync(complexProperty);
            _exportingReportsToExcel.OtherCost(package, otherCost);

            var interestCost = await _reportsService.InterestCostAsync(complexProperty);
            _exportingReportsToExcel.InterestCost(package, interestCost.Item1);

            var constructionCostForecast = await _reportsService.ConstructionCostForecastAsync(complexProperty, interestCost.Item2);
            var fileBytes = _exportingReportsToExcel.ConstructionCostForecast(package, constructionCostForecast);

            string fileName = "ConstructionForecastingModel.xlsx";
            string contentType = "application/octet-stream";

            return File(fileBytes, contentType, fileName);
        }
    }
}
