using Baseline.ItemConfig.API.Models.Requests;
using Baseline.ItemConfig.Application;
using Microsoft.AspNetCore.Mvc;

namespace Baseline.ItemConfig.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class UiTabController : ControllerBase
{
    private readonly UiTabService _uiTabService;

    public UiTabController(UiTabService uiTabService)
    {
        _uiTabService = uiTabService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUiTabs()
    {
        var result = await _uiTabService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUiTab([FromBody] CreateUiTabRequest request)
    {
        var result = await _uiTabService.Create(request.Name);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUiTab(Guid id)
    {
        await _uiTabService.Delete(id);
        return NoContent();
    }
}
