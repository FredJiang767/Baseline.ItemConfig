using Baseline.ItemConfig.Application;
using Baseline.ItemConfig.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Baseline.ItemConfig.API.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class CatalogController : ControllerBase
    {
        private readonly UiTabService _uiTabService;
        private readonly UiSubTabService _uiSubTabService;
        private readonly ItemService _itemService;

        public CatalogController(UiTabService uiTabService, ItemService itemService, UiSubTabService uiSubTabService)
        {
            _uiTabService = uiTabService;
            _itemService = itemService;
            _uiSubTabService = uiSubTabService;
        }

        [HttpPost]
        public async Task<IActionResult> GetItems()
        {
            var itemResult = new List<ItemReadDto>();
            var tabs = await _uiTabService.GetAll();
            foreach (var tab in tabs)
            {
                var subTabs = await _uiSubTabService.GetSubTabsByTabId(tab.UiTabId);
                foreach (var subTab in subTabs)
                {
                    var items = await _itemService.GetItemsBySubTabId(subTab.UiSubTabId);
                    itemResult.AddRange(items);
                }
            }

            return Ok(itemResult);
        }
    }
}
