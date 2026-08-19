using ForecastingModelParameters.Application.Services;
using ForecastingModelParameters.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ForecastingModelParameters.Presentation
{
    [ApiController]
    public class UpdateDataController(UpdateDataService updateDataService) : ControllerBase
    {
        private readonly UpdateDataService _updateDataService = updateDataService;

        [HttpGet("ConstructionCostByProperty")]
        public async Task<IActionResult> UpdateAsync(ConstructionCostByProperty сonstructionCostByProperty)
        {
            //await _updateDataService.ConstructionCostByPropertyAsync();

            return NoContent();
        }
    }
}
