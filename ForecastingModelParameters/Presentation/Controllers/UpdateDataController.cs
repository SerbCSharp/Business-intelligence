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

        [HttpGet("RequestProjectCostingData")]
        public async Task<IActionResult> RequestProjectCostingDataAsync(int property, int category, int period, [Required] string complexProperty = "ЖК ПЕРВОЕ МЕСТО")
        {
            var constructionCostByProperty = await _updateDataService.ProjectCostingDataAsync(complexProperty, property, category, period);
            _exportingReportsToExcel.ProjectCostingData(constructionCostByProperty, complexProperty, period);

            return NoContent();
        }

        [HttpGet("SaveProjectCostingData")]
        public async Task<IActionResult> SaveProjectCostingDataAsync([Required] string complexProperty = "ЖК ПЕРВОЕ МЕСТО")
        {
            await _updateDataService.SaveProjectCostingDataAsync(complexProperty);

            return NoContent();
        }
    }
}
