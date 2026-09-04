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

        [HttpGet("SaveAllProjectCostingData")]
        public async Task<IActionResult> SaveAllProjectCostingDataAsync([Required] string complexProperty = "ЖК ПЕРВОЕ МЕСТО")
        {
            await _updateDataService.SaveAllProjectCostingDataAsync(complexProperty);

            return NoContent();
        }
    }
}
