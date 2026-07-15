using Baseline.ItemConfig.Application;
using Microsoft.AspNetCore.Mvc;

namespace Baseline.ItemConfig.API.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class CatalogController : ControllerBase
    {
        private readonly UiTabService _uiTabService;
        private readonly ItemService _itemService;

        public CatalogController(UiTabService uiTabService, ItemService itemService)
        {
            _uiTabService = uiTabService;
            _itemService = itemService;
        }

        [HttpPost]
        public async Task<IActionResult> GetItems()
        {
            var result = await _uiTabService.GetAll();
            var items = await _itemService.GetAll();

            return Ok(result);
        }
    }
}
