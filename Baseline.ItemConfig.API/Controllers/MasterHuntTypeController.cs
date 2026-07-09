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
            var result = await _mhtService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMasterHuntType([FromBody] CreateMasterHuntTypeRequest request)
        {
            var result = await _mhtService.Create(request.Name);
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteMasterHuntType(Guid id)
        {
            await _mhtService.Delete(id);
            return NoContent();
        }

        public record CreateMasterHuntTypeRequest(string Name);
    }
}
