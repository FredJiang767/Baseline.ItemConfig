using Baseline.ItemConfig.API.Models.Requests;
using Baseline.ItemConfig.Application;
using Microsoft.AspNetCore.Mvc;

namespace Baseline.ItemConfig.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class HuntTypeLicenseYearController : ControllerBase
{
    private readonly HuntTypeLicenseYearService _licenseYearService;

    public HuntTypeLicenseYearController(HuntTypeLicenseYearService licenseYearService)
    {
        _licenseYearService = licenseYearService;
    }

    [HttpGet]
    public async Task<IActionResult> GetHuntTypeLicenseYears([FromQuery] Guid? masterHuntTypeId)
    {
        var result = await _licenseYearService.GetAll(masterHuntTypeId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateHuntTypeLicenseYear([FromBody] CreateHuntTypeLicenseYearRequest request)
    {
        var result = await _licenseYearService.Create(
            request.MasterHuntTypeId,
            request.Year,
            request.StartDate,
            request.EndDate);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteHuntTypeLicenseYear(Guid id)
    {
        await _licenseYearService.Delete(id);
        return NoContent();
    }
}
