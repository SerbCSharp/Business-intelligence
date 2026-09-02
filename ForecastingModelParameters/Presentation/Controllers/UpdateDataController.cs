using ForecastingModelParameters.Application.Services;
using ForecastingModelParameters.Presentation.ReportsToExcel;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ForecastingModelParameters.Presentation.Controllers
{
    [ApiController]
    public class UpdateDataController(UpdateDataService updateDataService, ExportingReportsToExcel exportingReportsToExcel) : ControllerBase
    {
        private readonly UpdateDataService _updateDataService = updateDataService;
        private readonly ExportingReportsToExcel _exportingReportsToExcel = exportingReportsToExcel;

        [HttpGet("RequestPropertyAndCategories")]
        public async Task<IActionResult> RequestPropertyAndCategoriesAsync(int property, int category, [Required] string complexProperty = "ЖК КИПАРИС")
        {
            var constructionCostByProperty = await _updateDataService.RequestPropertyAsync(complexProperty, property);
            _exportingReportsToExcel.RequestProjectCostingData(constructionCostByProperty, complexProperty, "ConstructionCostByProperty");
            var salesValueByCategory = await _updateDataService.RequestCategoriesAsync(complexProperty, category);
            _exportingReportsToExcel.RequestProjectCostingData(salesValueByCategory, complexProperty, "SalesValueByCategory");
            var otherFixedCost = await _updateDataService.RequestOtherFixedCostAsync(complexProperty);
            _exportingReportsToExcel.RequestProjectCostingData(otherFixedCost, complexProperty, "OtherFixedCost");
            var otherPercentageCost = await _updateDataService.RequestOtherPercentageCostAsync(complexProperty);
            _exportingReportsToExcel.RequestProjectCostingData(otherPercentageCost, complexProperty, "OtherPercentageCost");

            return NoContent();
        }

        [HttpGet("RequestByPeriods")]
        public async Task<IActionResult> RequestByPeriodsAsync(int period, [Required] string complexProperty = "ЖК КИПАРИС")
        {
            var constructionCostByPeriod = await _updateDataService.RequestByPeriodsConstructionAsync(complexProperty, period);
            _exportingReportsToExcel.RequestProjectCostingData(constructionCostByPeriod, complexProperty, "ConstructionCostByPeriod");
            var salesValueByPeriod = await _updateDataService.RequestBySalesPeriodsAsync(complexProperty, period);
            _exportingReportsToExcel.RequestProjectCostingData(salesValueByPeriod, complexProperty, "SalesValueByPeriod");
            var otherFixedCostByPeriod = await _updateDataService.RequestOtherFixedCostByPeriodAsync(complexProperty, period);
            _exportingReportsToExcel.RequestProjectCostingData(otherFixedCostByPeriod, complexProperty, "OtherFixedCostByPeriod");
            var оtherPercentageCostByPeriod = await _updateDataService.RequestOtherPercentageCostByPeriodAsync(complexProperty, period);
            _exportingReportsToExcel.RequestProjectCostingData(оtherPercentageCostByPeriod, complexProperty, "OtherPercentageCostByPeriod");

            return NoContent();
        }

        [HttpGet("SaveAllProjectCostingData")]
        public async Task<IActionResult> SaveAllProjectCostingDataAsync([Required] string complexProperty = "ЖК КИПАРИС")
        {
            await _updateDataService.SaveAllProjectCostingDataAsync(complexProperty);

            return NoContent();
        }
    }
}
