using Microsoft.AspNetCore.Mvc;
using Baseline.ItemConfig.Application;

namespace Baseline.ItemConfig.API.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class MasterHuntTypeController : ControllerBase
    {
        private readonly MasterHuntTypeService _mhtService;

        public MasterHuntTypeController(MasterHuntTypeService mhtService)
        {
            _mhtService = mhtService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMasterHuntTypes()
        {
            var result = await _mhtService.GetMasterHuntTypes();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetMasterHuntType(Guid id)
        {
            var result = await _mhtService.GetMasterHuntType(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMasterHuntType([FromBody] CreateMasterHuntTypeRequest request)
        {
            var result = await _mhtService.CreateMasterHuntType(request.Name);
            return CreatedAtAction(nameof(GetMasterHuntType), new { id = result.Id }, result);
        }

        public record CreateMasterHuntTypeRequest(string Name);
    }
}
