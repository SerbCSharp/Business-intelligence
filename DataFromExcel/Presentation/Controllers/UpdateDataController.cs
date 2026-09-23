using DataFromExcel.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataFromExcel.Presentation.Controllers
{
    [ApiController]
    public class UpdateDataController(UpdateDataService updateDataService, IConfiguration configuration) : ControllerBase
    {
        private readonly UpdateDataService _updateDataService = updateDataService;
        private readonly IConfiguration _configuration = configuration;

        [HttpGet("Update")]
        public async Task<IActionResult> UpdateAsync()
        {
            await _updateDataService.ObjectOfSaleInPurchasePaymentAsync();
            await _updateDataService.ObjectOfSaleInContractAsync();
            await _updateDataService.TotalFloorAreaAsync();
            await _updateDataService.AreaOfActivityAsync();
            await _updateDataService.AccountingTransactionAsync();
            return NoContent();
        }

        [HttpGet("Company")]
        public IActionResult Company()
        {
            string company = _configuration["FileSettings:FilePath"];
            return Ok(company[(company.LastIndexOf('\\') + 1)..]);
        }
    }
}
