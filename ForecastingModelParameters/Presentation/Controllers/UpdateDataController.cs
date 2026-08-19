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
        public async Task<IActionResult> RequestPropertyAndCategoriesAsync([Required] string complexProperty, [Required] int property, [Required] int category)
        {
            var constructionCostByProperty = await _updateDataService.GetConstructionCostByPropertyAsync(complexProperty, property);
            _exportingReportsToExcel.Browse(constructionCostByProperty);

            return NoContent();
        }
    }
}
