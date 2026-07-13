using Baseline.ItemConfig.API.Models.Requests;
using Baseline.ItemConfig.Application;
using Microsoft.AspNetCore.Mvc;

namespace Baseline.ItemConfig.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class OutletTypeItemController : ControllerBase
{
    private readonly OutletTypeItemService _outletTypeItemService;

    public OutletTypeItemController(OutletTypeItemService outletTypeItemService)
    {
        _outletTypeItemService = outletTypeItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOutletTypeItems()
    {
        var result = await _outletTypeItemService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOutletTypeItem([FromBody] CreateOutletTypeItemRequest request)
    {
        var result = await _outletTypeItemService.Create(request.OutletTypeId, request.ItemId);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteOutletTypeItem(Guid id)
    {
        await _outletTypeItemService.Delete(id);
        return NoContent();
    }
}
