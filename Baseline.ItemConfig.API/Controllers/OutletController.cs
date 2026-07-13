using Baseline.ItemConfig.API.Models.Requests;
using Baseline.ItemConfig.Application;
using Microsoft.AspNetCore.Mvc;

namespace Baseline.ItemConfig.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class OutletController : ControllerBase
{
    private readonly OutletService _outletService;

    public OutletController(OutletService outletService)
    {
        _outletService = outletService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOutlets()
    {
        var result = await _outletService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOutlet([FromBody] CreateOutletRequest request)
    {
        var result = await _outletService.Create(request.Name, request.OutletTypeId);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteOutlet(Guid id)
    {
        await _outletService.Delete(id);
        return NoContent();
    }
}
