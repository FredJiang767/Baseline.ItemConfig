using Baseline.ItemConfig.API.Models.Requests;
using Baseline.ItemConfig.Application;
using Microsoft.AspNetCore.Mvc;

namespace Baseline.ItemConfig.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class OutletTypeController : ControllerBase
{
    private readonly OutletTypeService _outletTypeService;

    public OutletTypeController(OutletTypeService outletTypeService)
    {
        _outletTypeService = outletTypeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOutletTypes()
    {
        var result = await _outletTypeService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOutletType([FromBody] CreateOutletTypeRequest request)
    {
        var result = await _outletTypeService.Create(request.Name);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteOutletType(Guid id)
    {
        await _outletTypeService.Delete(id);
        return NoContent();
    }
}
