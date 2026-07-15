using Baseline.ItemConfig.API.Models.Requests;
using Baseline.ItemConfig.Application;
using Microsoft.AspNetCore.Mvc;

namespace Baseline.ItemConfig.API.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class RootItemNumberController : ControllerBase
{
    private readonly RootItemNumberService _rootItemNumberService;

    public RootItemNumberController(RootItemNumberService rootItemNumberService)
    {
        _rootItemNumberService = rootItemNumberService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRootItemNumbers()
    {
        var result = await _rootItemNumberService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRootItemNumber([FromBody] CreateRootItemNumberRequest request)
    {
        var result = await _rootItemNumberService.Create(request.RootItemNumber, request.RootItemDescription);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteRootItemNumber(Guid id)
    {
        await _rootItemNumberService.Delete(id);
        return NoContent();
    }
}
