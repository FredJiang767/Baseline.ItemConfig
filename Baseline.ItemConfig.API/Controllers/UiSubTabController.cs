using Baseline.ItemConfig.API.Models.Requests;
using Baseline.ItemConfig.Application;
using Microsoft.AspNetCore.Mvc;

namespace Baseline.ItemConfig.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class UiSubTabController : ControllerBase
{
    private readonly UiSubTabService _uiSubTabService;

    public UiSubTabController(UiSubTabService uiSubTabService)
    {
        _uiSubTabService = uiSubTabService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUiSubTabs()
    {
        var result = await _uiSubTabService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUiSubTab([FromBody] CreateUiSubTabRequest request)
    {
        var result = await _uiSubTabService.Create(request.Name, request.UiTabId);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUiSubTab(Guid id)
    {
        await _uiSubTabService.Delete(id);
        return NoContent();
    }
}
