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
        public async Task<IActionResult> RequestPropertyAndCategoriesAsync([Required] string complexProperty, int property, int category)
        {
            var constructionCostByProperty = await _updateDataService.RequestPropertyAsync(complexProperty, property);
            _exportingReportsToExcel.ConstructionCostByProperty(constructionCostByProperty, complexProperty);
            var salesValueByCategory = await _updateDataService.RequestCategoriesAsync(complexProperty, category);
            _exportingReportsToExcel.SalesValueByCategory(salesValueByCategory, complexProperty);
            var otherCost = await _updateDataService.RequestOtherCostAsync(complexProperty);
            _exportingReportsToExcel.OtherCost(otherCost, complexProperty);

            return NoContent();
        }

        [HttpGet("RequestByPeriods")]
        public async Task<IActionResult> RequestByPeriodsAsync([Required] string complexProperty, int period)
        {
            var constructionCostByPeriod = await _updateDataService.RequestByPeriodsConstructionAsync(complexProperty, period);
            _exportingReportsToExcel.ConstructionCostByPeriod(constructionCostByPeriod, complexProperty);
            var salesValueByPeriod = await _updateDataService.RequestBySalesPeriodsAsync(complexProperty, period);
            _exportingReportsToExcel.SalesValueByPeriod(salesValueByPeriod, complexProperty);
            var otherCostByPeriod = await _updateDataService.RequestOtherCostByPeriodAsync(complexProperty);
            _exportingReportsToExcel.OtherCostByPeriod(otherCostByPeriod, complexProperty);

            return NoContent();
        }

        [HttpGet("SaveAllProjectCostingData")]
        public async Task<IActionResult> SaveAllProjectCostingDataAsync([Required] string complexProperty)
        {
            await _updateDataService.SaveAllProjectCostingDataAsync(complexProperty);

            return NoContent();
        }
    }
}
